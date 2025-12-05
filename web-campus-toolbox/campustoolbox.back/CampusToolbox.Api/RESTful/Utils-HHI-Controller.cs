using System; using System.Threading.Tasks; using Microsoft.AspNetCore.Mvc; using CampusToolbox.Service.HHI; using Microsoft.AspNetCore.Hosting; using System.Text.RegularExpressions; using System.IO; using CampusToolbox.Api;
using CampusToolbox.Model.Back.Utils.HappyHandingIn;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CampusToolbox.Api.Helpers;
using CampusToolbox.Service.Interfaces;
using CampusToolbox.Model.Front.Utils.HappyHandingIn;
using CampusToolbox.Service.Exceptions;
using System.Collections.Generic;
using static CampusToolbox.Model.Back.Utils.HappyHandingIn.HHIModel;

namespace CampusToolbox.Back.Utils.HappyHandingIn {      [Route( "~/api/utils/hhi" )]     public class HomeController : Controller {         private readonly IHHIService _HHIService;
        private readonly IExceptionToHttpStatusCode Do;
        private readonly ITokenService _TokenService;

        public HomeController(
            IExceptionToHttpStatusCode @do,             IHHIService HHIService,             ITokenService tokenService
            ) {             Do = @do;             _HHIService = HHIService;
            _TokenService = tokenService;
        }          [Route( "admin/update/prefix" )]         [HttpPost]         public IActionResult UpdatePrefix() {
            return Do.Action( () => {
                _HHIService.AdminUpdatePrefixs( WebHelper.GetObjectFromJsonInRequest<PrefixModel>( Request ) );
            } );
        }
                 [Route( "admin/update/task" )]         [HttpPost]         public IActionResult UpdateTask() {
            return Do.Action( () => {
                _HHIService.AdminUpdateTasks( WebHelper.GetObjectFromJsonInRequest<AssignedTaskModel>( Request ) );
            } );
        }

        [Route( "admin/dashboard" )]         [HttpPost]         public IActionResult GetDashBoard() {
            return null;
        }
         [Route( "admin/get-prefixs" )]         [HttpGet]         public JsonResult GetPrefixs() {
            return Json( ( ( HHIModel )_HHIService.GetHHIModel() ).Prefixs  );
        }          [Route( "getw" )]
        [HttpGet]
        public JsonResult GetWorks() {
            return Json( ( ( HHIModel )_HHIService.GetHHIModel() ).Works );
        }         [Route( "getp" )]
        [HttpGet]
        public JsonResult GetP() {
            return Json( ( ( HHIModel )_HHIService.GetHHIModel() ).Prefixs );
        }          [Route( "get/images" )]         [HttpPost]         public IActionResult GetImages() {
            return Do.ActionAndReturn( () => {
                return _HHIService.GetViewModel( WebHelper.GetObjectFromJsonInRequest<HHIFrontFetchCommitsModel>( Request ), _TokenService, Request );
            } );
        }

        [Route( "confirm/info" )]         [HttpPost]         public IActionResult ConfirmInfo() {
            return Do.Action( () => {
                throw new NotImplementedApiException();
            } );
        }

        [Route( "upload/images" )]         [HttpPost]         public IActionResult CommitImages() {
            return Do.Action( () => {
                _HHIService.CommitImages( WebHelper.GetObjectFromJsonInRequest<HHIFrontUploadImageModel>( Request ), _TokenService, Request );
            } );
        }
         [Route( "upload/files" )]         [HttpPost]         public IActionResult CommitFiles() {
            return Do.Action( () => {
                throw new NotImplementedApiException();
            } );
        }

        [Route( "upload-images" )]         [HttpPost]         public async Task<IActionResult> FileSave( [FromServices]IHostingEnvironment env ) {               int imgCount = Convert.ToInt32( Request.Form["imageCount"] );             for( int i = 0; i < imgCount; i++ ) {                 string blobImg = null;                 var blobSrc = Request.Form[i.ToString()];                  int ownerId = 0; // hold on                 int taskId = 0;

                //var match = Regex.Match( blobSrc.ToString(), "data:image/jpeg;base64,([\\w\\W]*)$" );
                //if( match.Success ) {
                //    blobImg = match.Groups[1].Value;
                //} else {
                //    var match2 = Regex.Match( blobSrc.ToString(), "data:image/png;base64,([\\w\\W]*)$" );
                //    blobImg = match2.Groups[1].Value;
                //}
                //if( blobImg == null ) {
                //    continue;
                //}
                //byte[] imgBytes = new byte[0];
                //try {
                //    imgBytes = Convert.FromBase64String( blobImg );

                //    MemoryStream imgMemStream = new MemoryStream( imgBytes );

                //    // TODO:
                //    var imgStream = new FileStream( Guid.NewGuid().ToString() + ".png", FileMode.OpenOrCreate );
                //    await imgMemStream.CopyToAsync( imgStream );
                //    imgStream.Close();
                //} catch( Exception ex ) { }
            }             return Ok( "Successfully Uploaded!" );         }     } } 