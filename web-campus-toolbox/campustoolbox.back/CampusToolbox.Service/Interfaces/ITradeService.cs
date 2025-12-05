using CampusToolbox.Model.Back.Trade;
using System.Collections.Generic;

namespace CampusToolbox.Service.Interfaces {
    public interface ITradeService {
        bool Buy( int buyerId, SupplyModel good );
        void Dispose();
        void ModifyDemand( DemandModel demand );
        void ModifySupply( SupplyModel supply );
        void PublishDemand( DemandModel demand );
        void PublishSupply( SupplyModel supply );
        List<SupplyModel> GetAllSupplies();
        List<DemandModel> GetAllDemands();
        List<TradeModel> GetAllTrades();
        List<DemandModel> DemandFilter(
                    ref List<DemandModel> dt,
                    int count,
                    string tag,
                    string si,
                    decimal map,
                    decimal mip );
        List<SupplyModel> SupplyFilter(
                    ref List<SupplyModel> dt,
                    int count,
                    string tag,
                    string si,
                    decimal map,
                    decimal mip );
        void DeleteDemand( DemandModel demand );
        void DeleteSupply( SupplyModel supply );
    }
}