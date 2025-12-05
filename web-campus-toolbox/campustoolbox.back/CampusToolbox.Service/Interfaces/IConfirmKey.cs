using CampusToolbox.Model.Back.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Service.Interfaces {
    public interface IConfirmKey : IService {
        Dictionary<string, AccountBackModel> GetAccountConfirms();
        Dictionary<string, AccountBackModel> GetResetPassword();
    }
}
