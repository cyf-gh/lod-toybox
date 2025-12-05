using AutoMapper;
using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Back.Trade;
using CampusToolbox.Model.Front.Trade;
using CampusToolbox.Model.Security;
using CampusToolbox.Security;
using CampusToolbox.Security.v1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusToolbox.Api {
    [Route( "~/api/test" )]
    public class TestContoller : Controller {
        private readonly IMapper _Mapper;
        private readonly ILogger<TestContoller> logger;

        public TestContoller( IMapper Mapper, ILogger<TestContoller> logger ) {
            _Mapper = Mapper;
            this.logger = logger;
        }

        [Route( "fetch-json" )]         [HttpGet]
        public JsonResult FetchJson() {
            return Json( new FrontTokenModel() );
        }

        [Route( "ip" )]
        [HttpGet]
        public JsonResult GetIP() {
            var a = Request.Cookies["test"];
            return Json( Request.HttpContext.Connection.RemoteIpAddress.ToString() );
        }
    }
}
