using CampusToolbox.Model.Back.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Service.Databases {
    public class AccountContext : DbContext {
        private readonly IConfiguration config;

        public DbSet<AccountBackModel> Accounts { get; set; }

        public AccountContext( IConfiguration config ) {
            this.config = config;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ) {
            optionsBuilder
                .UseNpgsql( config["ctb-account-sqlconnectionstring"] );
            base.OnConfiguring( optionsBuilder );
        }
    }
}