using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using CampusToolbox.Security;
using CampusToolbox.Security.v1;
using CampusToolbox.Service.Databases;
using CampusToolbox.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CampusToolbox.Service.Exceptions;
using CampusToolbox.Service.Account;

namespace CampusToolbox.Service.Implements {

    public class TokenServiceImpl : ITokenService {
        private TokenSessionContext _TokenSession;

        private ITokenCreator TokenCreator;

        public void Dispose() { }

        public TokenServiceImpl( TokenSessionContext TokenSession ) {
            TokenCreator = new TokenCreator();
            _TokenSession = TokenSession;
        }

        private TokenModel findSepecificToken( AccountBackModel account ) {
            if( _TokenSession.Tokens.Count() == 0 ) {
                return null;
            }
            return _TokenSession.Tokens.ToList().Find( a => a.AccountId == account.Id );
        }

        public FrontTokenModel CreateNewToken( AccountBackModel account ) {
            var token = findSepecificToken( account );
            var newTokenString = TokenCreator.CreateByAccount( account );
            
            if( token != null ) {
                // 如果该账户已有token，则更新
                token.Token = newTokenString;
                _TokenSession.Update( findSepecificToken( account ) );
            } else {                 
                // 如果没有token，则添加
                var newToken = TokenCreator.CreateByAccount( account );
                _TokenSession.Add( new TokenModel {
                    Id = 0, AccountId = account.Id, Token = newTokenString
                } );
            }
            _TokenSession.SaveChanges();
            return new FrontTokenModel { Token = newTokenString };
        }

        public bool ValidateToken( FrontTokenModel token ) {
            if( _TokenSession.Tokens.Count() == 0 ) {
                return false;
            }
            return _TokenSession.Tokens.ToList().Find( t => t.Token == token.Token ) != null;
        }

        public int FindAccountIdByToken( FrontTokenModel token ) {
            if( _TokenSession.Tokens.Count() == 0 ) {
                throw new NoSuchTokenException( token.Token );
            }
            foreach( var tokenModel in _TokenSession.Tokens.ToList() ) {
                if ( tokenModel.Token == token.Token ) { 
                    return tokenModel.AccountId;
                }
            }
            throw new NoSuchTokenException( token.Token );
        }

        public FrontTokenModel GetTokenFromCookie( HttpRequest request ) {
            var token = request.Cookies["token"];
            if( string.IsNullOrEmpty( token ) ) {
                throw new NoTokenException();
            }
            return new FrontTokenModel { Token = request.Cookies["token"] };
        }

        public int FindAccountIdByCookie( HttpRequest request ) {
            try {
                return FindAccountIdByToken( GetTokenFromCookie( request ) );
            } catch {
                throw;
            }
        }

        public int FindAccountIdByTokenString( string token ) {
            try {
                return FindAccountIdByToken( new FrontTokenModel { Token = token } );
            } catch {
                throw;
            }
        }

        public AccountBackModel GetAccountBack( HttpRequest request, IAccountService accountService ) {
            try {
                return accountService.GetUserById( FindAccountIdByCookie( request ) );
            } catch {
                throw;
            }
        }
    }
}
