using CampusToolbox.Model.Back.Account;
using CampusToolbox.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Service.Implements {
    public class ConfirmKey : IConfirmKey {
        private Dictionary<string, AccountBackModel> _ConfirmQueue = new Dictionary<string, AccountBackModel>();
        private Dictionary<string, AccountBackModel> _ResetPasswordQueue = new Dictionary<string, AccountBackModel>();

        public ConfirmKey() {

        }

        public void Dispose() { }

        public Dictionary<String, AccountBackModel> GetAccountConfirms() {
            return _ConfirmQueue;
        }

        public Dictionary<String, AccountBackModel> GetResetPassword() {
            return _ResetPasswordQueue;
        }
    }
}
