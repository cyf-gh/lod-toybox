using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using CampusToolbox.Service.Implements;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampusToolbox.Api {
    [Route( "api/static-data" )]
    public class StaticDataController : Controller {
        private readonly IStaticDataService staticDataService;

        public StaticDataController( IStaticDataService staticDataService ) {
            this.staticDataService = staticDataService;
        }
        [HttpGet]
        [Route( "cn-provinces" )]
        public IActionResult GetProvince() {
            return Content( staticDataService.GetProvinces() );
        }

        [HttpGet]
        [Route( "cn-areas" )]
        public IActionResult GetAreas() {
            return Content( staticDataService.GetAreas() );
        }

        [HttpGet]
        [Route( "cn-colleges" )]
        public IActionResult GetColleges() {
            return Content( staticDataService.GetColleges() );
        }

        [HttpGet]
        [Route( "grades" )]
        public IActionResult GetGrades() {
            return Content( staticDataService.GetGrades() );
        }
    }
}
