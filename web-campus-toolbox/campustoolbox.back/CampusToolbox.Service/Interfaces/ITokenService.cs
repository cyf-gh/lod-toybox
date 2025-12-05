using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using CampusToolbox.Service.Account;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CampusToolbox.Service.Interfaces {
    public interface ITokenService : IService {
        FrontTokenModel CreateNewToken( AccountBackModel account );
        bool ValidateToken( FrontTokenModel token );
        
        /// <summary>
        /// 通过Token得到账户Id
        /// </summary>
        /// <param name="token">前端Token模型</param>
        /// <returns>用户id</returns>
        /// <exception cref="NoSuchTokenException"></exception>
        int FindAccountIdByToken( FrontTokenModel token );
        int FindAccountIdByTokenString( string token );


        /// <summary>
        /// 通过cookie token获取账户实例
        /// </summary>
        /// <param name="request"></param>
        /// <param name="accountService"></param>
        /// <seealso cref="GetUserById"/>
        /// <exception cref="NoSuchTokenException"></exception>
        /// <exception cref="NoTokenException"></exception>
        AccountBackModel GetAccountBack( HttpRequest request, IAccountService accountService );
        FrontTokenModel GetTokenFromCookie( HttpRequest request );
        int FindAccountIdByCookie( HttpRequest request );
    }
}
