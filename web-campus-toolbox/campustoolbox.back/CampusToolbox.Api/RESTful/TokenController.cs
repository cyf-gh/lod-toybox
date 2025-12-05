using CampusToolbox.Api.Helpers;
using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using CampusToolbox.Service.Account;
using CampusToolbox.Service.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusToolbox.Api {
    [Route( "~/api/token" )]
    public class TokenController : Controller {
        private readonly ITokenService _TokenService;
        private readonly IAccountService _AccountService;
        private readonly IExceptionToHttpStatusCode Do;

        public TokenController(
            IExceptionToHttpStatusCode @do,
            ITokenService tokenService,
            IAccountService accountService ) {
            _TokenService = tokenService;
            _AccountService = accountService;
            Do = @do;
        }

        [EnableCors( Cors.Origins_AngularWeb )]
        [Route( "validate" )]
        [HttpPost]
        public JsonResult Validate() {
            var frontToken = WebHelper.GetObjectFromJsonInRequest<FrontTokenModel>( Request );

            return Json( _TokenService.ValidateToken( frontToken ) );
        }

        [Route( "reflect-account" )]
        [HttpGet]
        public IActionResult ReflectAccount() {
            return Do.ActionAndReturn( () => { return _TokenService.GetAccountBack( Request, _AccountService ).ToViewModel( AccountAuthority.Self ); } );
        }

    }
}
