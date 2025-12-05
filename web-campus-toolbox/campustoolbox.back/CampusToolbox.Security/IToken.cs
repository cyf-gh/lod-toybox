using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Security {
    public interface ITokenCreator {
        string CreateByAccount( AccountBackModel account );
    }
}
