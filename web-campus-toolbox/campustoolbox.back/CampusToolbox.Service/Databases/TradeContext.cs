using CampusToolbox.Model.Back.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Service.Databases {
    public class TradeContext : DbContext {
        private readonly IConfiguration config;

        public TradeContext( IConfiguration config ) {
            this.config = config;
        }


        public DbSet<SupplyModel> Supplies { get; set; }
        public DbSet<DemandModel> Demands { get; set; }
        public DbSet<TradeModel> Trades { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ) {
            optionsBuilder
                .UseNpgsql( config["ctb-trade-sqlconnectionstring"] );
            base.OnConfiguring( optionsBuilder );
        }
    }
}
