using System;
using System.Collections.Generic;
using System.Linq;
using CampusToolbox.Model.Back.Account;
using CampusToolbox.Security;
using CampusToolbox.Service.Databases;
using stLib.CS.Net;
using Hangfire;
using CampusToolbox.Security.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Extensions.Configuration;
using CampusToolbox.Model._Shared.Account;
using AutoMapper;
using CampusToolbox.Service.Interfaces;
using CampusToolbox.Model.Front.Account;
using CampusToolbox.Service.Exceptions;

namespace CampusToolbox.Service.Account {
    class MailHelper {
        private Mail _Mail;
        private string MailTemplateDirectory = Path.Combine( Environment.CurrentDirectory, "_EmailTemplates" );
        private string ContextTemplateConfirm;
        private string ContextTemplateReset;
        private string SiteRoot;
        public MailHelper( string mail, string pw, string siteRoot ) {
            _Mail = new Mail( mail, pw );
            ContextTemplateConfirm = File.ReadAllText( Path.Combine( MailTemplateDirectory, "confirm.template.html" ) );
            ContextTemplateReset = File.ReadAllText( Path.Combine( MailTemplateDirectory, "resetpsword.template.html" ) );
            SiteRoot = siteRoot;
        }

        public void SendConfirmLink( string target, string guid, string username ) {
            string context = ContextTemplateConfirm.Replace( "????", SiteRoot + "/api/account/register/confirm?p=" + guid )
                .Replace( "@@@@", username );

            _Mail.SendMail( target, context, "CampusToolbox 账户注册验证", "CampusToolbox 委员会" );
        }

        public void SendPasswordResetKey( string target, string rand4 ) {
            string context = ContextTemplateReset.Replace( "???", rand4 );

            _Mail.SendMail( target, context, "CampusToolbox 重置密码验证码", "CampusToolbox 委员会" );
        }
    }

    public class AccountServiceImpl : IAccountService {
        public AccountServiceImpl(
            AccountContext accountContext,
            ILogger<AccountServiceImpl> logger,
            IConfiguration config,
            IMapper mapper,
            IConfirmKey confirmKey ) {
            _AccountContext = accountContext;
            this.logger = logger;
            this.mapper = mapper;
            _Encrypt = new EncryptImpl();
            _Mail = new MailHelper( config["ctb-email-add"], config["ctb-email-passwd"], config["site-root"] );
            _confirmKey = confirmKey;
            _ConfirmQueue = _confirmKey.GetAccountConfirms();
            _ResetPasswordQueue = _confirmKey.GetResetPassword();
        }
        public void Dispose() { }

        private MailHelper _Mail;
        private IEncrypt _Encrypt;
        private AccountContext _AccountContext;
        private readonly ILogger<AccountServiceImpl> logger;
        private readonly IMapper mapper;
        private readonly IConfirmKey _confirmKey;
        private Dictionary<string, AccountBackModel> _ConfirmQueue;
        private Dictionary<string, AccountBackModel> _ResetPasswordQueue;

        public bool Confirm( string guid ) {
            if( !_ConfirmQueue.ContainsKey( guid ) ) {
                return false;
            }
            var account = _ConfirmQueue[guid];
            if( account == null ) {
                return false;
            } else {
                account.Relieable.IsConfirmed = true;
                account.Identity = AccountIdentity.Common;
                _ConfirmQueue.Remove( guid );
                _AccountContext.SaveChanges();
                return true;
            }
        }

        public void cleanResetPassword( string rand4 ) {
            if( !_ConfirmQueue.ContainsKey( rand4 ) ) {
                logger.LogInformation( "In cleanResetPassword() GUID[{0}] does not exsit.", rand4 );
                return;
            }
            logger.LogInformation( "In cleanResetPassword() GUID[{0}] removed", rand4 );
            _ResetPasswordQueue.Remove( rand4 );
        }

        public void cleanConfirm( string guid ) {
            if( !_ConfirmQueue.ContainsKey( guid ) ) {
                logger.LogInformation( "In cleanConfirm() rand4[{0}] does not exsit.", guid );
                return;
            }
            logger.LogInformation( "In cleanConfirm() rand4[{0}] removed", guid );
            var account = _ConfirmQueue[guid];
            _AccountContext.Remove( account );
            _AccountContext.SaveChanges();
            _ConfirmQueue.Remove( guid );
        }

        public void PrepareResetPassword( AccountBackModel account ) {
            string rand4;
            do {
                rand4 = stLib.CS.Random.Number4();
            } while( _ResetPasswordQueue.ContainsKey( rand4 ) );

            logger.LogDebug( "rand4[{0}] created", rand4 );

            _Mail.SendPasswordResetKey( account.Relieable.Email, rand4 );
            _ResetPasswordQueue[rand4] = account;

            BackgroundJob.Schedule( () => cleanResetPassword( rand4 ), TimeSpan.FromMinutes( 10 ) );
        }

        public bool ResetPassword( AccountBackModel account, ResetPasswordModel resetPasswordModel ) {
            if( !_ResetPasswordQueue.ContainsKey( resetPasswordModel.Key ) ) {
                return false;
            } else {
                // 碰巧撞上了其他账户的
                if( account.Id != _ResetPasswordQueue[resetPasswordModel.Key].Id ) {
                    return false;
                }
            }

            account.Sys.PasswordEncrypted = _Encrypt.EncryptPassword( resetPasswordModel.PasswordPlain );
            _AccountContext.Accounts.Update( account );
            _AccountContext.SaveChanges();
            return true;
        }

        public void TryConfirm( AccountBackModel account ) {
            // 生成验证码
            var newGuid = Guid.NewGuid().ToString();

            // 开始计时用户是否在指定时间里验证了账户
            _ConfirmQueue[newGuid] = account;
            BackgroundJob.Schedule( () => cleanConfirm( newGuid ), TimeSpan.FromMinutes( 10 ) );

            _AccountContext.AddAsync( account );
            // 发送邮件
            _Mail.SendConfirmLink( account.Relieable.Email, newGuid, account.AbsVisiable.NickName );
        }


        public void Register( AccountRegisterModel newAccount ) {
            /*
            var dbAccount = new AccountBackModel {
                Id = 0,
                Sys = new _SharedSystemAccountModel { PasswordEncrypted = _Encrypt.EncryptPassword( newAccount.PlainPassword ) },
                AbsVisiable = newAccount.AbsVisiable,
                Relieable = newAccount.Relieable,
            };

            dbAccount.Identity = AccountIdentity.Unconfirmed;
            dbAccount.Relieable.IsConfirmed = false;
            */
            var dbAccount = mapper.Map<AccountBackModel>( newAccount );
            // 检查账户是否存在
            var exsitedAccount = _AccountContext.Accounts.FirstOrDefault(
                a => a.Relieable.Phone == newAccount.Relieable.Phone || a.Relieable.Email == newAccount.Relieable.Email
            );
            if( exsitedAccount != null ) {
                throw new FailedResetPasswordException();
            }
            TryConfirm( dbAccount );
        }

        public AccountBackModel Login( AccountLoginModel login ) {
            AccountBackModel account = new AccountBackModel();

            if( _AccountContext.Accounts.Count() == 0 ) {
                throw new ControllerException("No account in database");
            }
            var accounts = _AccountContext.Accounts
                        .Include( a => a.AbsVisiable )
                        .Include( a => a.Relieable )
                        .Include( a => a.Sys )
                        .ToList();

            switch( login.LoginBy ) {
                case AccountLoginBy.Phone:
                    account = accounts.Find( a => a.Relieable.Phone == login.LoginName );
                    break;
                case AccountLoginBy.Email:
                    account = accounts.Find( a => a.Relieable.Email == login.LoginName );
                    break;
                case AccountLoginBy.QR:
                    // directly fetch
                    break;
                default:
                    return null;
            }

            if( account == null ) {
                throw new PasswordOrAccountWrongException();
            }

            if( account.Sys.PasswordEncrypted != _Encrypt.EncryptPassword( login.Password ) ) {
                throw new PasswordOrAccountWrongException();
            }
            return account;
        }

        public AccountViewModel GetUserById( Int32 id, AccountAuthority authority ) {
            try {
                var backModel = GetUserById( id );
                backModel.Authority = authority;
                return backModel.ToViewModel( authority );
            } catch {
                throw;
            }
        }

        public AccountBackModel GetUserById( Int32 id ) {
            var backModel = ( ( _AccountContext.Accounts?
               .Include( a => a.AbsVisiable )
               .Include( a => a.Relieable )
               .Include( a => a.Sys )
               .ToList().Find( a => a.Id == id ) ) );
            if( backModel == null ) {
                throw new NoSuchUserException();
            }
            return backModel;
        }

        public void UpdateUserInfo( AccountUpdateInfoPostModel updateInfo, AccountBackModel account ) {
            account.AbsVisiable.NickName = updateInfo.Name;
            account.AbsVisiable.Hp = updateInfo.Hp;
            _AccountContext.Accounts.Update( account );
            _AccountContext.SaveChanges();
        }

        public void UpdateAccount( AccountUpdateInfoPostModel updateInfo, AccountBackModel back ) {
            back.AbsVisiable.Hp = updateInfo.Hp;
            back.AbsVisiable.NickName = updateInfo.Name;
            _AccountContext.Accounts.Update( back );
            _AccountContext.SaveChanges();
        }

    }

}
