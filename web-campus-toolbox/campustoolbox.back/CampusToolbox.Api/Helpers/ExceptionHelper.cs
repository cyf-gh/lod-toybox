using CampusToolbox.Model.Front;
using CampusToolbox.Service.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CampusToolbox.Api.Helpers {
    /// <summary>
    /// 将后端异常转化为前端错误消息与http stauts code的转换器。
    /// </summary>
    public static class ExceptionHelper {
        // public static ExceptionToHttpStatusCodeHelper Do { get; set; } = new ExceptionToHttpStatusCodeHelper();
        public delegate object Operations();
        public delegate void NoReturnOperations();
    }

    public interface IExceptionToHttpStatusCode {
        IActionResult ActionAndReturn( ExceptionHelper.Operations op );
        IActionResult Action( ExceptionHelper.NoReturnOperations op );
    }

    public class ExceptionToHttpStatusCodeHelper : IExceptionToHttpStatusCode {

        public readonly ILogger<ExceptionToHttpStatusCodeHelper> Logger;

        public ExceptionToHttpStatusCodeHelper( ILogger<ExceptionToHttpStatusCodeHelper> Logger ) {
            this.Logger = Logger;
        }

        public IActionResult ActionAndReturn( ExceptionHelper.Operations op ) {
            try {
                var res = new JsonResult( op.Invoke() );
                res.StatusCode = ( int )HttpStatusCode.OK;
                return res;
            } catch( ControllerException ex ) {
                return ex.HttpResult();
            } catch( Exception ex ) {
                Logger.LogError( ex.ToString() );
                return new StatusCodeResult( ( int )HttpStatusCode.InternalServerError );
            }
        }
        /// <summary>
        /// 该方法常用于不返回序列数据的api，或者说是只返回状态码的api
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public IActionResult Action( ExceptionHelper.NoReturnOperations op ) {
            try {
                op();
            } catch( ControllerException ex ) {
                return ex.HttpResult();
            } catch( Exception ex ) {
                Logger.LogError( ex.ToString() );
                return new StatusCodeResult( ( int )HttpStatusCode.InternalServerError );
            }
            return new OkResult();
        }
    }
}
