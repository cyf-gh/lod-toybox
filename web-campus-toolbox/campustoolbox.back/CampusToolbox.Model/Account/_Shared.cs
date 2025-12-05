using CampusToolbox.Model.Back.Trade;
using System;

namespace CampusToolbox.Model._Shared.Account {
    public enum Grade {
        NA, // Who is not a school student
        TS, JCS, // Technical school student, junior college student

        /* Undergraduate Student */
        UG,

        /* Postgraduate Student */
        PG,

        /* Doctoral Student */
        D,

        BD, // Bachelor Degree
        MD, // Master Degree
        DD, // Doctor Degree
    }
    #region AccountShared
    public class _SharedAbsolutelyVisiableAccountModel {
        public int Id { get; set; }
        public string Hp { get; set; }
        public string NickName { get; set; }
        public string College { get; set; }
    }

    public class _SharedSystemAccountModel {
        public int Id { get; set; }
        public string PasswordEncrypted { get; set; }
    }

    public class _SharedRelieableAccountModel {
        public int Id { get; set; }
        // privacy infos
        public string City { get; set; }
        public string Name { get; set; }
        public string District { get; set; }
        // contact infos
        public string Email { get; set; }
        public string Phone { get; set; }
        // school infos
        public Grade Grade { get; set; }
        // account meta infos
        public bool IsConfirmed { get; set; }
    }
    #endregion
    #region TradeShared
    public class _SharedTradeGoodModel {
        public int Id { get; set; }
        // 基本信息
        public string Name { get; set; } // XSS 风险项
        public string Desc { get; set; } // XSS 风险项
        public DateTime PublishDate { get; set; }
        public AvailableTo AvailableTo { get; set; }
        public bool IsAvailable { get; set; }
        // 用分号隔开
        // TODO: Tag checker
        public string Tag { get; set; }
    }
    public class _SharedTradeGoodFrontViewModel {
        // 基本信息
        public string Name { get; set; } // XSS 风险项
        public string Desc { get; set; } // XSS 风险项
        public DateTime PublishDate { get; set; }
        public AvailableTo AvailableTo { get; set; }
        public bool IsAvailable { get; set; }
        // 用分号隔开
        // TODO: Tag checker
        public string Tag { get; set; }
    }
    #endregion
}
