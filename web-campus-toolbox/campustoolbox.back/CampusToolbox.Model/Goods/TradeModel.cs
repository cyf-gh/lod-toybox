using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Model.Back.Trade {
    public enum TradeLevel {
        BuyerPayed = 0,
        BuyerConfirmed = 1
    }
    public class TradeModel {
        public int Id { get; set; }
        public string UniName { get; set; }
        public int GoodId { get; set; }
        public int BuyerId { get; set; }
        public TradeLevel Level { get; set; }
    }
}

namespace CampusToolbox.Model.Front.Trade {

    public class TradeFrontModel {
    }
}