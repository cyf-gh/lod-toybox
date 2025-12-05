using System;
using System.Collections.Generic;
using System.Text;
using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using stLib.CS.Security;

namespace CampusToolbox.Security.v1 {
    public class TokenCreator : ITokenCreator {
        private const string magic = "7F95E71AF6FCD245BE17D74174A62839";

        private string generateToken( AccountBackModel account ) {
            string chaos = account.Relieable.Email + account.Relieable.Phone + DateTime.Now.ToString() + magic;
            SHA sha = new SHA();
            return sha.SHA256EncryptUTF8( chaos );
        }
        public string CreateByAccount( AccountBackModel account ) {
            return generateToken( account );
        }
    }
}