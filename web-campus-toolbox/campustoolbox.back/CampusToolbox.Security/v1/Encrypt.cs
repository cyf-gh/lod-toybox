using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Security.v1 {
    using CampusToolbox.Security;
    using stLib.CS.Security;

    public class EncryptImpl : IEncrypt {
        private SHA _sha;
        public EncryptImpl() {
            _sha = new SHA();
        }

        public String EncryptPassword( String plain ) {
            return _sha.SHA512EncryptUTF8( plain );
        }

        public Boolean IsCorrectPassword( String plain, String encryptedInDb ) {
            return EncryptPassword( plain ).Equals( encryptedInDb );
        }
    }
}
