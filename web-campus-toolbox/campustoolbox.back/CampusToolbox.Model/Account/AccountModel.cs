using CampusToolbox.Model._Shared.Account;
using CampusToolbox.Model.Front.Account;

namespace CampusToolbox.Model.Front.Account {
    public class AccountViewModel {
        public _SharedRelieableAccountModel Relieable;
        public _SharedAbsolutelyVisiableAccountModel AbsVisiable;
    }

    public class AccountUpdateInfoPostModel {
        public string Name;
        public string Hp; // base64
    }
}

namespace CampusToolbox.Model.Back.Account {
    public enum AccountIdentity {
        Common,
        VIP,
        Admin,
        Unconfirmed
    }
    public enum AccountAuthority {
        Public,
        Self,
        Relieable // public to public means relieable is public
    }

    public enum AccountLoginBy {
        Phone,
        Email,
        QR
    }
    public class AccountLoginModel {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public AccountLoginBy LoginBy { get; set; }
    }

    public class AccountRegisterModel {
        public AccountRegisterModel() {
            Sys = new _SharedSystemAccountModel();
            AbsVisiable = new _SharedAbsolutelyVisiableAccountModel();
            Relieable = new _SharedRelieableAccountModel();
        }

        public _SharedSystemAccountModel Sys { get; set; }
        public _SharedAbsolutelyVisiableAccountModel AbsVisiable { get; set; }
        public _SharedRelieableAccountModel Relieable { get; set; }
        public string PlainPassword { get; set; }
    }

    public class ResetPasswordModel {
        public string Key { get; set; }
        public string PasswordPlain { get; set; }
    }

    public class AccountBackModel {
        public int Id { get; set; }

        public _SharedSystemAccountModel Sys { get; set; }
        public _SharedAbsolutelyVisiableAccountModel AbsVisiable { get; set; }
        public _SharedRelieableAccountModel Relieable { get; set; }

        public AccountAuthority Authority;

        public AccountIdentity Identity { get; set; }
        public AccountViewModel ToViewModel( AccountAuthority authority ) {
            switch( authority ) {
                case AccountAuthority.Public:
                    return new AccountViewModel {
                        AbsVisiable = this.AbsVisiable
                    };
                case AccountAuthority.Self:
                    return new AccountViewModel {
                        AbsVisiable = this.AbsVisiable,
                        Relieable = this.Relieable
                    };
                case AccountAuthority.Relieable:
                    return new AccountViewModel {
                        AbsVisiable = this.AbsVisiable,
                        Relieable = this.Relieable
                    };
                default:
                    return null;
            }
        }
    }
}
