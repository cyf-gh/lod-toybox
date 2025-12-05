using CampusToolbox.Api.Helpers;
using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Front.Account;
using CampusToolbox.Service.Account;
using CampusToolbox.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusToolbox.Api {
    [Route( "~/api/user" )]
    public class UserContoller : Controller {
        private readonly IAccountService _AccountService;
        private readonly IExceptionToHttpStatusCode Do;
        private readonly ITokenService _TokenService;

        public UserContoller(
            IAccountService accountService,
            IExceptionToHttpStatusCode @do,
            ITokenService tokenService
            ) {
            _AccountService = accountService;
            Do = @do;
            this._TokenService = tokenService;
        }

        // '/api/user/id?v=1'
        [Route( "id" )]         [HttpGet]
        public JsonResult ConfirmAccount( int v ) {
            return Json( _AccountService.GetUserById( v, AccountAuthority.Public ) );
        }

        [Route( "modify-info" )]         [HttpPost]
        public IActionResult ModifyInfo() {
            return Do.Action( () => {
                _AccountService.UpdateAccount(
                    WebHelper.GetObjectFromJsonInRequest<AccountUpdateInfoPostModel>( Request ),
                    _TokenService.GetAccountBack( Request, _AccountService )
                );
            } );
        }
    }
}
