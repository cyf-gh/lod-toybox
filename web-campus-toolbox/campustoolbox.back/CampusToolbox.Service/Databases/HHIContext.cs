using Microsoft.EntityFrameworkCore;
using CampusToolbox.Model.Back.Utils.HappyHandingIn;
using System;
using Microsoft.Extensions.Configuration;

namespace CampusToolbox.Service.Databases {
    public class HHIContext : DbContext {

        private readonly IConfiguration config;

        public HHIContext( IConfiguration config ) {
            this.config = config;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ) {
            optionsBuilder
                .UseNpgsql( config["ctb-utils-hhi-sqlconnectionstring"] );
            base.OnConfiguring( optionsBuilder );
        }

        public DbSet<HHIModel.PrefixModel> prefixModels { get; set; }
        public DbSet<HHIModel.AssignedTaskModel> workModels { get; set; }

        public DbSet<HHIClassModel> classModels { get; set; }
        public DbSet<HHIBackModel> backModel { get; set; }
    }
}
