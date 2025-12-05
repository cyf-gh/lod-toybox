using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CampusToolbox.Api;
using CampusToolbox.Api.Helpers;
using CampusToolbox.Mapping;
using CampusToolbox.Service.Account;
using CampusToolbox.Service.Databases;
using CampusToolbox.Service.HHI;
using CampusToolbox.Service.Implements;
using CampusToolbox.Service.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CampusToolbox.Back {
    public class Startup {
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup( IHostingEnvironment environment, IConfiguration configuration ) {
            Environment = environment;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services ) {
            services.AddEntityFrameworkNpgsql();

            // Databases
            services.AddDbContext<AccountContext>();
            services.AddDbContext<TokenSessionContext>();
            services.AddDbContext<HHIContext>();
            services.AddDbContext<TradeContext>();

            // Services
            services.AddTransient<IHHIService, HHIServiceImpl>();
            services.AddTransient<IAccountService, AccountServiceImpl>();
            services.AddTransient<ITokenService, TokenServiceImpl>();
            services.AddTransient<ITradeService, TradeServiceImpl>();

            services.AddSingleton<IExceptionToHttpStatusCode, ExceptionToHttpStatusCodeHelper>();
            services.AddSingleton<IConfirmKey, ConfirmKey>();
            services.AddSingleton<IStaticDataService, StaticDataService>();

            services.AddSession();

            services.AddMvc().SetCompatibilityVersion( CompatibilityVersion.Version_2_1 );
            services.AddHangfire( config => { } );

            // 支付中间件
            // Wechat
            // services.AddWeChatPay();
            // AliPay
            
            services.AddSingleton( new MapperConfiguration( mc => {
                mc.AddProfile( new MappingProfile() );
            } ).CreateMapper() );

            // Cors
            // 网页端口请求
            services.AddCors( options => {
                options.AddPolicy( Cors.Origins_AngularWeb,
                builder => {
                    builder.WithOrigins( Configuration["ctb-front-host"] );
                } );
            } );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env, IConfiguration config ) {
            // Hangfire service
            GlobalConfiguration.Configuration.UseSqlServerStorage( config["hangfire-sqlconnectionstring"] );

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseForwardedHeaders( new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto } );

            if( env.IsDevelopment() ) {
            } else {
            }
            // TODO: 添加前端域名跨域访问
            app.UseCors( Cors.Origins_AngularWeb );
            
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc();
        }
    }
}
