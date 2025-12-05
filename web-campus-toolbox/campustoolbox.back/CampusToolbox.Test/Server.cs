using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CampusToolbox.Api;
using CampusToolbox.Back;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Xunit;
using Xunit.Priority;

namespace CampusToolbox.Test {
    public static class TestHelper {
        public const string projectDir = @"C:\Development\CampusToolbox.Back\CampusToolbox.Api";
        public static TestServer Server = null;
        public static HttpClient Client { get; }
        public static HttpClient ClientWithWrongToken { get; }

        public const string Token = "51F0CCE12B02727F2ED9C50F31AE709BD3159DC19777442CAA33A38549957E2A";
        public const string WrongToken = "????????????????????????????????????????????????????????????";

        static TestHelper() {
            Server = new TestServer( WebHost.CreateDefaultBuilder()
                 .UseEnvironment( "Development" )
                 .UseContentRoot( projectDir )
                 .UseConfiguration( new ConfigurationBuilder()
                     .SetBasePath( projectDir )
                     .AddJsonFile( "appsettings.json" )
                     .Build()
                 )
                 .UseStartup<Startup>() );

            var handler = new HttpClientHandler() { UseCookies = false };

            Client = Server.CreateClient();
            Client.DefaultRequestHeaders.Add( "Cookie", "token="+Token );
            Client.DefaultRequestHeaders.Add( "user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0" );
            Client.DefaultRequestHeaders.Add( "Connection", "Keep-Alive" );
            Client.DefaultRequestHeaders.Add( "Keep-Alive", "timeout=1000" );

            ClientWithWrongToken = Server.CreateClient();
            ClientWithWrongToken.DefaultRequestHeaders.Add( "Cookie", "token=" + WrongToken );
            ClientWithWrongToken.DefaultRequestHeaders.Add( "user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0" );
            ClientWithWrongToken.DefaultRequestHeaders.Add( "Connection", "Keep-Alive" );
            ClientWithWrongToken.DefaultRequestHeaders.Add( "Keep-Alive", "timeout=1000" );

        }

        public static async Task<HttpResponseMessage> TestPost<T>( string api, string jsonString ) {
            return await TestHelper.Client.PostAsJsonAsync(
                api,
                WebHelper.GetObjectFromJsonString<T>( jsonString ) );
        }

        public static async Task<HttpResponseMessage> TestPost( string api, object obj ) {
            var message = new HttpRequestMessage( HttpMethod.Post, api );
            message.Content = new StringContent( JsonConvert.SerializeObject( obj ) );
            return await Client.SendAsync( message );
        }

        public static async Task<HttpResponseMessage> TestPostWithWrongToken( string api, object obj = null ) {
            var message = new HttpRequestMessage( HttpMethod.Post, api );
            message.Content = ( obj == null ) ? new StringContent( "" ) : new StringContent( JsonConvert.SerializeObject( obj ) );
            return await ClientWithWrongToken.SendAsync( message );
        }

        public static async Task<HttpResponseMessage> TestGet( string api ) {
            return await Client.GetAsync( api );
        }
    }
}
