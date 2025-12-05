using CampusToolbox.Model;
using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Front.Account;
using CampusToolbox.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Service.Account {

    public interface IAccountService : IService {

        /// <summary>
        /// 登陆账户
        /// </summary>
        /// <exception cref="FailedResetPasswordException"></exception>
        /// <param name="account"></param>
        void Register( AccountRegisterModel account );

        bool Confirm( string guid );
        /// <summary>
        /// 账户登录
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// <exception cref="PasswordOrAccountWrongException"></exception>
        /// <exception cref="UnknownException">当数据库中没有帐户时抛出</exception>
        AccountBackModel Login( AccountLoginModel login );

        /// <summary>
        /// 通过id获取账户实例
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NoSuchUserException"></exception>
        AccountViewModel GetUserById( int id, AccountAuthority authority );
        AccountBackModel GetUserById( int id );
        bool ResetPassword( AccountBackModel account, ResetPasswordModel resetPasswordModel );
        /// <summary>
        /// 发送重置密码
        /// </summary>
        /// <param name="account"></param>
        void PrepareResetPassword( AccountBackModel account );
        /// <summary>
        /// 重新发送账户认证验证码
        /// </summary>
        /// <param name="account"></param>
        void TryConfirm( AccountBackModel account );
        /// <summary>
        /// 更新账户信息
        /// </summary>
        /// <param name="updateInfo"></param>
        /// <param name="back"></param>
        void UpdateAccount( AccountUpdateInfoPostModel updateInfo, AccountBackModel back );
    }
}
