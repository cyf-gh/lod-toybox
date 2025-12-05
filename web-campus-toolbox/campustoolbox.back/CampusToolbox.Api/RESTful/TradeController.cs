using AutoMapper;
using CampusToolbox.Api.Helpers;
using CampusToolbox.Model._Shared.Account;
using CampusToolbox.Model.Back.Trade;
using CampusToolbox.Model.Front;
using CampusToolbox.Model.Front.Trade;
using CampusToolbox.Service.Account;
using CampusToolbox.Service.Exceptions;
using CampusToolbox.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using stLib.CS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CampusToolbox.Api.RESTful {
    [Route( "~/api/trade" )]
    public class TradeController : Controller {
        private readonly ITokenService _TokenService;
        private readonly ITradeService _TradeService;
        private readonly IAccountService _AccountService;
        private readonly IMapper _Mapper;
        private readonly IExceptionToHttpStatusCode Do;

        public TradeController( IAccountService accountService,
            ITokenService tokenService,
            ITradeService tradeService,
            IExceptionToHttpStatusCode @do,
            IMapper mapper ) {
            _AccountService = accountService;
            _TokenService = tokenService;
            _TradeService = tradeService;
            _Mapper = mapper;
            Do = @do;
        }

        private DemandModel FrontToBack_DemandModel() {
            try {
                var demandFrontModel = WebHelper.GetObjectFromJsonInRequest<DemandFrontModel>( Request );
                var demandBack = _Mapper.Map<DemandModel>( demandFrontModel );
                demandBack.Base = _Mapper.Map<_SharedTradeGoodModel>( demandFrontModel );

                demandBack.Base.IsAvailable = true;
                demandBack.Base.PublishDate = DateTime.Now;
                demandBack.Base.AvailableTo = AvailableTo.Public; // all public

                var account = _TokenService.GetAccountBack( Request, _AccountService );

                demandBack.PublisherId = account.Id;
                demandBack.Collage = account.AbsVisiable.College;
                return demandBack;
            } catch {
                throw;
            }
        }

        private SupplyModel FrontToBack_SupplyModel() {
            try {
                var supplyFrontModel = WebHelper.GetObjectFromJsonInRequest<SupplyFrontModel>( Request );
                var supplyBack = _Mapper.Map<SupplyModel>( supplyFrontModel );
                supplyBack.Base = _Mapper.Map<_SharedTradeGoodModel>( supplyFrontModel );

                supplyBack.Base.IsAvailable = true;
                supplyBack.Base.PublishDate = DateTime.Now;
                supplyBack.Base.AvailableTo = AvailableTo.Public; // all public

                var account = _TokenService.GetAccountBack( Request, _AccountService );

                supplyBack.PublisherId = account.Id;
                supplyBack.Collage = account.AbsVisiable.College;
                return supplyBack;
            } catch {
                throw;
            }
        }

        string GetUserCollegeFromToken() {
            try {
                var account = _TokenService.GetAccountBack( Request, _AccountService );
                var college = account.AbsVisiable.College;
                return college;
            } catch( Exception ) {
                return null;
            }
        }

        [Route( "publish-demand" )]
        [HttpPost]
        public IActionResult PublishDemand() {
            return Do.Action( () => _TradeService.PublishDemand( FrontToBack_DemandModel() ) );
        }

        [Route( "publish-supply" )]
        [HttpPost]
        public IActionResult PublishSupply() {
            return Do.Action( () => _TradeService.PublishSupply( FrontToBack_SupplyModel() ) );
        }

        [Route( "modify-demand" )]
        [HttpPost]
        public IActionResult ModifyDemand() {
            return Do.Action( () => _TradeService.ModifyDemand( FrontToBack_DemandModel() ) );
        }

        [Route( "modify-supply" )]
        [HttpPost]
        public IActionResult ModifySupply() {
            return Do.Action( () => _TradeService.ModifySupply( FrontToBack_SupplyModel() ) );
        }

        [Route( "demands" )]
        [HttpGet]
        public IActionResult GetDemands( int count, string tag, string si, decimal map, decimal mip ) {
            var college = GetUserCollegeFromToken();
            if( string.IsNullOrEmpty( college ) ) {
                return new NoSuchTokenException( Request.Cookies["token"] ).HttpResult();
            }
            var demands = _TradeService.GetAllDemands().FindAll( d => d.Collage == college || d.Collage == Defaults.Collage );
            var filteredDemands = demands;

            filteredDemands = _TradeService.DemandFilter( ref demands, count, tag, si, map, mip );

            List<DemandFrontViewModel> viewDemands = _Mapper.Map<List<DemandModel>, List<DemandFrontViewModel>>( filteredDemands );

            for( int i = 0; i < viewDemands.Count; i++ ) {
                viewDemands[i].PublisherName = _AccountService.GetUserById( filteredDemands[i].PublisherId ).AbsVisiable.NickName;
                viewDemands[i].PublisherHp = _AccountService.GetUserById( filteredDemands[i].PublisherId ).AbsVisiable.Hp;
            }

            return Json( viewDemands );
        }

        [Route( "own-demands" )]
        [HttpGet]
        public IActionResult GetOwnDemands() {
            var currentUserId = _TokenService.GetAccountBack( Request, _AccountService ).Id;
            return Json( _TradeService.GetAllDemands().FindAll( d => d.PublisherId == currentUserId ) );
        }

        [Route( "own-supplies" )]
        [HttpGet]
        public IActionResult GetOwnSupplies() {
            var currentUserId = _TokenService.GetAccountBack( Request, _AccountService ).Id;
            return Json( _TradeService.GetAllSupplies().FindAll( d => d.PublisherId == currentUserId ) );
        }

        [Route( "delete-demand" )]
        [HttpGet]
        public IActionResult DeleteDemand( int id ) {
            var demand = _TradeService.GetAllDemands().Find( d => d.Id == id );
            if( demand.PublisherId != _TokenService.GetAccountBack( Request, _AccountService ).Id ) {
                return BadRequest( "no authorization" );
            }
            _TradeService.DeleteDemand( demand );
            return Ok();
        }

        [Route( "delete-supply" )]
        [HttpGet]
        public IActionResult DeleteSupply( int id ) {
            var supply = _TradeService.GetAllSupplies().Find( d => d.Id == id );
            if( supply.PublisherId != _TokenService.GetAccountBack( Request, _AccountService ).Id ) {
                return BadRequest("no authorization");
            }
            _TradeService.DeleteSupply( supply );
            return Ok();
        }

        /// <summary>
        /// 获取Supply
        /// </summary>
        /// <remarks>
        /// 未验证输入参数
        /// </remarks>
        /// <param name="count"></param>
        /// <param name="tag"></param>
        /// <param name="si">some info</param>
        /// <param name="map">max price</param>
        /// <param name="mip">min price</param>
        /// <returns></returns>
        [Route( "supplies" )]
        [HttpGet]
        public IActionResult GetSupplies( int count, string tag, string si, decimal map, decimal mip ) {
            var college = GetUserCollegeFromToken();
            if( string.IsNullOrEmpty( college ) ) {
                return new NoSuchTokenException( Request.Cookies["token"] ).HttpResult();
            }

            var supply = _TradeService.GetAllSupplies().FindAll( d => d.Collage == college || d.Collage == Defaults.Collage );
            List<SupplyModel> filteredSupplies = supply;

            filteredSupplies = _TradeService.SupplyFilter( ref filteredSupplies, count, tag, si, map, mip );

            var viewSupplies = _Mapper.Map<List<SupplyModel>, List<SupplyFrontViewModel>>( filteredSupplies );

            for( int i = 0; i < viewSupplies.Count; i++ ) {
                viewSupplies[i].PublisherName = _AccountService.GetUserById( filteredSupplies[i].PublisherId ).AbsVisiable.NickName;
                viewSupplies[i].PublisherHp = _AccountService.GetUserById( filteredSupplies[i].PublisherId ).AbsVisiable.Hp;
            }

            return Json( viewSupplies );
        }
    }
}
