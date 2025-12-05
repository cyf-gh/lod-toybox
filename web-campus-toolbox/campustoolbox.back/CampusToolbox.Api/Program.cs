using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace CampusToolbox.Back {
    public class Program {
        public static void Main( string[] args ) {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override( "Microsoft", LogEventLevel.Information )
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Logger( l => l.Filter.ByIncludingOnly( e => e.Level == LogEventLevel.Information ).WriteTo.RollingFile( @"Logs\{Date}-Info.log" ) )
                .WriteTo.Logger( l => l.Filter.ByIncludingOnly( e => e.Level == LogEventLevel.Debug ).WriteTo.RollingFile( @"Logs\{Date}-Debug.log" ) )
                .WriteTo.Logger( l => l.Filter.ByIncludingOnly( e => e.Level == LogEventLevel.Warning ).WriteTo.RollingFile( @"Logs\{Date}-Warning.log" ) )
                .WriteTo.Logger( l => l.Filter.ByIncludingOnly( e => e.Level == LogEventLevel.Error ).WriteTo.RollingFile( @"Logs\{Date}-Error.log" ) )
                .WriteTo.Logger( l => l.Filter.ByIncludingOnly( e => e.Level == LogEventLevel.Fatal ).WriteTo.RollingFile( @"Logs\{Date}-Fatal.log" ) )
                .CreateLogger();

            CreateWebHostBuilder( args ).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder( string[] args ) =>
            WebHost.CreateDefaultBuilder( args )
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
