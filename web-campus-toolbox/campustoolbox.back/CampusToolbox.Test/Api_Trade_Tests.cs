using CampusToolbox.Model.Front.Trade;
using CampusToolbox.Model.Security;
using CampusToolbox.Test;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CampusToolbox.Tests.Api {
    public class Trade {

        private readonly ITestOutputHelper output;

        public Trade( ITestOutputHelper output ) {
            this.output = output;
        }
        /*
        [Fact]
        public async Task Publish_A_New_Demand() {
            var response = await TestHelper.TestPost(
                $"/api/trade/publish-demand",
                new DemandFrontModel {
                    Id = 0,
                    Base = new Model._Shared.Account._SharedTradeGoodModel {
                        Id = 0,
                        AvailableTo = Model.Back.Trade.AvailableTo.SchoolMates,
                        Desc = "goooood",
                        IsAvailable = true,
                        Name = "thinkpadx270",
                        PublishDate = DateTime.Now,
                        Tag = "pc,cheap"
                    }
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );
        }

        [Fact]
        public async Task Publish_A_New_Supply() {
            var response = await TestHelper.TestPost(
                $"/api/trade/publish-supply",
                new SupplyFrontModel {
                    Id = 0,
                    Base = new Model._Shared.Account._SharedTradeGoodModel {
                        Id = 0,
                        AvailableTo = Model.Back.Trade.AvailableTo.SchoolMates,
                        Desc = "goooood",
                        IsAvailable = true,
                        Name = "thinkpadx270",
                        PublishDate = DateTime.Now,
                        Tag = "pc,cheap"
                    },
                    Images = new string[] { "12121e2eqwq", "afsdfasfadsfassa" },
                    PriceMax = 8000,
                    Price = 2000
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );
        }
        [Fact]
        public async Task Modify_A_Demand_And_Success() {
            var response = await TestHelper.TestPost(
               $"/api/trade/modify-demand",
               new DemandFrontModel {
                   Id = 0,
                   Base = new Model._Shared.Account._SharedTradeGoodModel {
                       Id = 0,
                       AvailableTo = Model.Back.Trade.AvailableTo.SchoolMates,
                       Desc = "doooogggg",
                       IsAvailable = true,
                       Name = "thinkpadx240",
                       PublishDate = DateTime.Now,
                       Tag = "pccc,cccheap"
                   }
               } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );

            var response2 = await TestHelper.TestPost(
                $"/api/trade/demands?count=0",
                new FrontTokenModel {
                    Token = TestHelper.Token
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );
            var viewDemandList = JsonConvert.DeserializeObject<List<DemandFrontViewModel>>( await response2.Content.ReadAsStringAsync() );
            Assert.NotNull( viewDemandList );
            Assert.Equal( "thinkpadx240", viewDemandList
                .Find( m => m.Base.Desc == "doooogggg" )
                .Base.Name );
        }


        [Fact]
        public async Task Modify_A_Supply_And_Success() {
            var response = await TestHelper.TestPost(
                $"/api/trade/modify-supply",
                new SupplyFrontModel {
                    Id = 1,
                    Base = new Model._Shared.Account._SharedTradeGoodModel {
                        Id = 0,
                        AvailableTo = Model.Back.Trade.AvailableTo.SchoolMates,
                        Desc = "doooooog",
                        IsAvailable = true,
                        Name = "thinkpadx260",
                        PublishDate = DateTime.Now,
                        Tag = "pc,morecheap"
                    },
                    Images = new string[] { "12121e2eqwq", "afsdfasfadsfassa" },
                    PriceMax = 7000,
                    Price = 3000
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );

            var response2 = await TestHelper.TestPost(
                $"/api/trade/supplies?count=0",
                new FrontTokenModel {
                    Token = TestHelper.Token
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );
            var viewSupplyList = JsonConvert.DeserializeObject<List<SupplyFrontViewModel>>( await response2.Content.ReadAsStringAsync() );
            Assert.NotNull( viewSupplyList );
            Assert.Equal( 7000, viewSupplyList
                .Find( m => m.Base.Name == "thinkpadx260" )
                .PriceMax );
        }
        */

        [Fact]
        public async Task Fetch_Demands_With_Token() {
            var response = await TestHelper.TestPost(
                $"/api/trade/demands?count=5",
                new FrontTokenModel {
                    Token = TestHelper.Token
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );
            var viewDemandList = JsonConvert.DeserializeObject<List<DemandFrontViewModel>>( await response.Content.ReadAsStringAsync() );
            Assert.NotNull( viewDemandList );
        }
        [Fact]
        public async Task Fetch_Demands_With_IncorrectToken() {
            var response = await TestHelper.TestPostWithWrongToken(
                $"/api/trade/demands?count=5" );
            Assert.Equal( HttpStatusCode.BadRequest, response.StatusCode );
            output.WriteLine( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync() ) );
        }
        [Fact]
        public async Task Fetch_Supplies_With_Token() {
            var response = await TestHelper.TestPost(
                $"/api/trade/supplies?count=5",
                new FrontTokenModel {
                    Token = TestHelper.Token
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );
            var viewDemandList = JsonConvert.DeserializeObject<List<SupplyFrontViewModel>>( await response.Content.ReadAsStringAsync() );
            Assert.NotNull( viewDemandList );
            Assert.Equal( 2, viewDemandList
                .Find( m => m.Base.Name == "thinkpadx270" )
                .Images
                .Length );
        }
        [Fact]
        public async Task Fetch_Supplies_With_IncorrectToken() {
            var response = await TestHelper.TestPostWithWrongToken(
                $"/api/trade/supplies?count=5" );
            Assert.Equal( HttpStatusCode.BadRequest, response.StatusCode );
            output.WriteLine( JsonConvert.SerializeObject( await response.Content.ReadAsStringAsync() ) );
        }
        [Fact]
        public async Task Fetch_Specific_Supplies() {
            var response = await TestHelper.TestPost(
                $"/api/trade/supplies?count=5&tag=pc&mip=0&map=10000&si=thinkpad",
                new FrontTokenModel {
                    Token = TestHelper.Token
                } );
            Assert.Equal( HttpStatusCode.OK, response.StatusCode );
            var viewDemandList = JsonConvert.DeserializeObject<List<SupplyFrontViewModel>>( await response.Content.ReadAsStringAsync() );
            Assert.NotNull( viewDemandList );
            output.WriteLine( JsonConvert.SerializeObject( viewDemandList ) );
        }
    }
}
