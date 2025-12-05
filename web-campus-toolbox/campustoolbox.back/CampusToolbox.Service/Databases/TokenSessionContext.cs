using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Service.Databases {
    public class TokenSessionContext : DbContext {
        private readonly IConfiguration config;

        public DbSet<TokenModel> Tokens { get; set; }

        public TokenSessionContext( IConfiguration config ) {
            this.config = config;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ) {
            optionsBuilder
                .UseNpgsql( config["ctb-token-sqlconnectionstring"] );
            base.OnConfiguring( optionsBuilder );
        }
    }
}
