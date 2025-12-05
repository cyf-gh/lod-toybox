using CampusToolbox.Api.Helpers;
using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using CampusToolbox.Service.Account;
using CampusToolbox.Service.Exceptions;
using CampusToolbox.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusToolbox.Api {
    [Route( "~/api/account" )]     public class AccountController : Controller {
        private readonly ITokenService _TokenService;
        private readonly IAccountService _AccountService;
        private readonly IExceptionToHttpStatusCode Do;

        public AccountController(
            IExceptionToHttpStatusCode @do,
            IAccountService accountService,
            ITokenService tokenService ) {
            _AccountService = accountService;
            _TokenService = tokenService;
            Do = @do;
        }

        [EnableCors( Cors.Origins_AngularWeb )]
        [Route( "login" )]
        [HttpPost]
        public IActionResult Login() {
            return Do.ActionAndReturn( () => {
                var login = WebHelper.GetObjectFromJsonInRequest<AccountLoginModel>( Request );
                var account = _AccountService.Login( login );

                account.Authority = AccountAuthority.Self;
                return _TokenService.CreateNewToken( account );
            } );
        }

        [Route( "reset/password/do" )]         [HttpPost]
        public IActionResult ResetPassword() {
            return Do.Action( () => {
                var reset = WebHelper.GetObjectFromJsonInRequest<ResetPasswordModel>( Request );
                var account = _TokenService.GetAccountBack( Request, _AccountService );
                if( !_AccountService.ResetPassword( account, reset ) ) {
                    throw new FailedResetPasswordException();
                }
            } );
        }

        [Route( "reset/password/send-key" )]         [HttpPost]
        public IActionResult SendPasswordResetKey() {
            return Do.Action( () => {
                _AccountService.PrepareResetPassword( _TokenService.GetAccountBack( Request, _AccountService ) );
            } );
        }

        [Route( "register/new" )]
        [HttpPost]
        public IActionResult NewAccount() {
            return Do.Action( () => {
                _AccountService.Register( WebHelper.GetObjectFromJsonInRequest<AccountRegisterModel>( Request ) );
            } );
        }

        [Route( "register/confirm" )]         [HttpGet]
        public IActionResult ConfirmAccount( string p ) {
            if( _AccountService.Confirm( p ) ) {
                return Ok();
            } else {
                return BadRequest();
            }
        }


        [Route( "register/send-confirm" )]         [HttpPost]
        public IActionResult TryConfirm() {
            return Do.Action( () => {
                var account = _TokenService.GetAccountBack( Request, _AccountService );
                if( account.Relieable.IsConfirmed ) {
                    return;
                }
                _AccountService.TryConfirm( account );
            } );
        }
    }
}