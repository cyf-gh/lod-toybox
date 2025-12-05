using CampusToolbox.Model.Front;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CampusToolbox.Service.Exceptions {

    public static class ActionResultHelper {
        public static IActionResult CreateResult( HttpStatusCode httpStatusCode, object content ) {
            var res = new ContentResult();
            res.Content = JsonConvert.SerializeObject( content );
            res.ContentType = "application/json;charset=utf-8";
            res.StatusCode = (int)httpStatusCode;
            return res;
        }
    }

    public class ControllerException : Exception {

        public ControllerException( string message ) : base( message ) {
        }

        public ControllerException( string message, Exception innerException ) : base( message, innerException ) {
        }

        public virtual IActionResult HttpResult() { return new BadRequestResult(); }
    }
    /// <summary>
    /// 不想管的谜之错误
    /// </summary>
    public class UnknownException : ControllerException {
        public UnknownException( string message ) : base( message ) {
        }

        public UnknownException( string message, Exception innerException ) : base( message, innerException ) {
        }
        public override IActionResult HttpResult() {
            return ActionResultHelper.CreateResult( HttpStatusCode.BadRequest, new ErrorInfoFrontModel {
                ErrorCode = ErrorInfoCode.Unknown,
                Detail = "Unknown Error."
            } );
        }
    }

    /// <summary>
    /// 没有符合的token
    /// </summary>
    public class NoSuchTokenException : ControllerException {
        const string msg = "No such Token: {0}.";
        public NoSuchTokenException( string tokenValue ) : base( String.Format( msg, tokenValue ) ) { }

        public override IActionResult HttpResult() {
            return ActionResultHelper.CreateResult( HttpStatusCode.OK, new ErrorInfoFrontModel {
                ErrorCode = ErrorInfoCode.InvalidToken,
                Detail = "Token Invalid. Please login again"
            } );
        }
    }
    /// <summary>
    /// cookie没有附带token
    /// </summary>
    public class NoTokenException : ControllerException {
        const string msg = "No available token";
        public NoTokenException() : base( msg ) { }

        public override IActionResult HttpResult() {
            return ActionResultHelper.CreateResult( HttpStatusCode.OK, new ErrorInfoFrontModel {
                ErrorCode = ErrorInfoCode.NoToken,
                Detail = "No Token. Please Login First."
            } );
        }
    }
    /// <summary>
    /// 表单错误，无法转化为对象
    /// TODO: 检查request源，防范dos
    /// </summary>
    public class InvalidContentException : ControllerException {
        const string msg = "Invalid Content";

        public InvalidContentException( HttpRequest request ) : base( msg ) { }

        public override IActionResult HttpResult() {
            return ActionResultHelper.CreateResult( HttpStatusCode.BadRequest, new ErrorInfoFrontModel {
                ErrorCode = ErrorInfoCode.InvalidContent,
                Detail = "Invalid Request Content."
            } );
        }
    }
    /// <summary>
    /// 该用户不存在
    /// </summary>
    public class NoSuchUserException : ControllerException {
        const string msg = "User does not exsit.";

        public NoSuchUserException() : base( msg ) { }

        public override IActionResult HttpResult() {
            return ActionResultHelper.CreateResult( HttpStatusCode.OK, new ErrorInfoFrontModel {
                ErrorCode = ErrorInfoCode.NoSuchUser,
                Detail = "User does not exsit."
            } );
        }
    }

    /// <summary>
    /// 用户名或密码错误
    /// </summary>
    public class PasswordOrAccountWrongException : ControllerException {
        const string msg = "Login Failed";

        public PasswordOrAccountWrongException() : base( msg ) { }

        public override IActionResult HttpResult() {
            return ActionResultHelper.CreateResult( HttpStatusCode.OK, new ErrorInfoFrontModel {
                ErrorCode = ErrorInfoCode.NoSuchUser,
                Detail = "Password or account is wrong."
            } );
        }
    }

    /// <summary>
    /// 重置密码失败
    /// </summary>
    public class FailedResetPasswordException : ControllerException {
        const string msg = "Reset Password Failed";

        public FailedResetPasswordException() : base( msg ) { }

        public override IActionResult HttpResult() {
            return ActionResultHelper.CreateResult( HttpStatusCode.OK, new ErrorInfoFrontModel {
                ErrorCode = ErrorInfoCode.FailedToReset,
                Detail = "Reset Failed."
            } );
        }
    }


    public class NotImplementedApiException : ControllerException {
        const string msg = "Not implemented yet.";

        public NotImplementedApiException() : base( msg ) { }

        public override IActionResult HttpResult() {
            return ActionResultHelper.CreateResult( HttpStatusCode.BadRequest, new ErrorInfoFrontModel {
                ErrorCode = ErrorInfoCode.NotImplementedApi,
                Detail = "Calling not implemented api."
            } );
        }
    }

}
