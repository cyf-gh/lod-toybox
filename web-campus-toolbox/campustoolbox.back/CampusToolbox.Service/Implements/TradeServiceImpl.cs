using CampusToolbox.Model.Back.Trade;
using CampusToolbox.Service.Databases;
using CampusToolbox.Service.Exceptions;
using CampusToolbox.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using stLib.CS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusToolbox.Service.Implements {
    public class TradeServiceImpl : ITradeService {
        private readonly TradeContext _TradeContext;

        public TradeServiceImpl( TradeContext tradeContext ) {
            _TradeContext = tradeContext;
        }

        public bool Buy( int buyerId, SupplyModel good ) {
            if( !good.Base.IsAvailable ) {
                throw new GoodNotAvaliableException();
            }
            var newTrade = new TradeModel {
                Id = 0,
                GoodId = good.Id,
                BuyerId = buyerId,
                Level = TradeLevel.BuyerPayed,
                UniName = Guid.NewGuid().ToString()
            };
            // 向数据库添加订单
            _TradeContext.Trades.Add( newTrade );

            // 商品已被拍下
            {
                good.Base.IsAvailable = false;
                _TradeContext.Supplies.Update( good );
            }
            Save();

            return true;
        }

        public List<SupplyModel> GetAllSupplies() {
            return _TradeContext.Supplies.Include( s => s.Base ).ToList();
        }

        public List<DemandModel> GetAllDemands() {
            return _TradeContext.Demands.Include( s => s.Base ).ToList();
        }

        public List<TradeModel> GetAllTrades() {
            return _TradeContext.Trades.ToList();
        }

        public void DeleteSupply(SupplyModel supply) { 
            _TradeContext.Supplies.Remove( supply );
            Save();
        }

        public void DeleteDemand( DemandModel demand ) {
            _TradeContext.Demands.Remove( demand );
            Save();
        }

        private void Save() {
            _TradeContext.SaveChanges();
        }

        private async void SaveAsync() {
            await _TradeContext.SaveChangesAsync();
        }

        public void PublishSupply( SupplyModel supply ) {
            _TradeContext.Supplies.Add( supply );
            Save();
        }

        public void PublishDemand( DemandModel demand ) {
            _TradeContext.Demands.Add( demand );
            Save();
        }

        public void ModifySupply( SupplyModel supply ) {
            _TradeContext.Supplies.Update( supply );
            Save();
        }

        public void ModifyDemand( DemandModel demand ) {
            _TradeContext.Demands.Update( demand );
            Save();
        }

        public void Dispose() {
        }

        public List<DemandModel> DemandFilter(
            ref List<DemandModel> dt,
            int count,
            string tag,
            string si,
            decimal map,
            decimal mip ) {

            var orgCount = dt.Count;

            // 返回匹配标签的项目
            if( !string.IsNullOrEmpty( tag ) ) {
                dt = dt.FindAll( m => TagHelper.IsTagsFullMatch( m.Base.Tag, tag ) );
            }
            // 返回价格区间内的项目
            if( map > 0 && mip >= 0 ) {
                dt = dt.FindAll( m => m.PriceMax <= map && m.PriceMin >= mip );
            }
            // 返回信息中包含关键字的项目
            if( !string.IsNullOrEmpty( si ) ) {
                dt = dt.FindAll(
                    m => m.Base.Name.Contains( si ) || m.Base.Desc.Contains( si )
                );
            }

            // 返回项目个数
            if( orgCount > count && count != 0 ) {
                dt = dt.GetRange( 0, count );
            }
            return dt;
        }

        public List<SupplyModel> SupplyFilter(
        ref List<SupplyModel> dt,
        int count,
        string tag,
        string si,
        decimal map,
        decimal mip ) {
            var orgCount = dt.Count;

            // 返回匹配标签的项目
            if( !string.IsNullOrEmpty( tag ) ) {
                dt = dt.FindAll( m => TagHelper.IsTagsFullMatch( m.Base.Tag, tag ) );
            }
            // 返回价格区间内的项目
            if( map > 0 ) {
                if( mip >= 0 ) {
                    dt = dt.FindAll( m => m.PriceMin <= map && m.PriceMin >= mip );
                }
            }
            // 返回信息中包含关键字的项目
            if( !string.IsNullOrEmpty( si ) ) {
                dt = dt.FindAll(
                    m => m.Base.Name.Contains( si ) || m.Base.Desc.Contains( si )
                );
            }

            // 返回项目个数
            if( orgCount > count && count != 0 ) {
                dt = dt.GetRange( 0, count );
            }
            return dt;
        }

    }
    public class GoodNotAvaliableException : ControllerException {
        public GoodNotAvaliableException()
            : base( "The good is not avaliable now." ) { }
    }

}
