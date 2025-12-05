using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Security {
    public interface IEncrypt {
        string EncryptPassword( string plain );
        bool IsCorrectPassword( String plain, String encryptedInDb );
    }
}
