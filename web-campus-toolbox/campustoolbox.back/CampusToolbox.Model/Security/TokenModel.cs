using CampusToolbox.Model.Back.Account;
using System;

namespace CampusToolbox.Model.Security {
    public class TokenModel {
        public int Id { get; set; }
        public string Token { get; set; }
        public int AccountId { get; set; }
    }

    public class FrontTokenModel {
        public string Token { get; set; }
    }
}
