using CampusToolbox.Model._Shared.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Model.Front.Trade {
    public class SupplyFrontModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Tag { get; set; }
        public string[] Images { get; set; } // base64图片
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
    }
    public class DemandFrontModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Tag { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
    }

    public class SupplyFrontViewModel {
        public _SharedTradeGoodFrontViewModel Base { get; set; }
        public string[] Images { get; set; } // base64图片
        public decimal PriceMax { get; set; }
        public decimal PriceMin { get; set; }
        public string PublisherName { get; set; }
        public string PublisherHp { get; set; }
    }

    public class DemandFrontViewModel {
        public _SharedTradeGoodModel Base { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public string PublisherName { get; set; }
        public string PublisherHp { get; set; }
    }
}

namespace CampusToolbox.Model.Back.Trade {
    public enum AvailableTo {
        Public,
        SchoolMates,
        Specificed
    }

    public static class Defaults {
        public const string Collage = "null";
    }

    public class SupplyModel {
        public int Id { get; set; }
        public _SharedTradeGoodModel Base { get; set; }

        // base64图片
        public string[] Images { get; set; }
        public string Collage { get; set; }

        public decimal PriceMax { get; set; }
        public decimal PriceMin { get; set; }
        // Link
        public int PublisherId { get; set; }
    }


    public class DemandModel {
        public int Id { get; set; }
        public _SharedTradeGoodModel Base { get; set; }
        public string Collage { get; set; }

        // 原价
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }

        // 用户链接
        public int PublisherId { get; set; }
    }
}
