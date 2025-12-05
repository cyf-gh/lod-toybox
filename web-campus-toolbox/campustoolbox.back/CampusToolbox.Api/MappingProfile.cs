using AutoMapper;
using CampusToolbox.Model._Shared.Account;
using CampusToolbox.Model.Back.Account;
using CampusToolbox.Model.Back.Trade;
using CampusToolbox.Model.Front.Trade;
using CampusToolbox.Security;
using CampusToolbox.Security.v1;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusToolbox.Mapping {

    public class PasswordEncrypt : IValueConverter<string, string> {
        public String Convert( String plain, ResolutionContext context ) {
            IEncrypt _Encrypt = new EncryptImpl();
            return _Encrypt.EncryptPassword( plain );
        }
    }

    public class MappingProfile : Profile {

        public MappingProfile() {
            IEncrypt encrypt = new EncryptImpl();
            CreateMap<SupplyFrontModel, SupplyModel>();
            CreateMap<SupplyModel, SupplyFrontModel>();
            CreateMap<SupplyModel, SupplyFrontViewModel>();
            CreateMap<SupplyFrontModel, _SharedTradeGoodModel>();


            CreateMap<DemandFrontModel, DemandModel>();
            CreateMap<DemandFrontModel, _SharedTradeGoodModel>();
            CreateMap<DemandModel, DemandFrontModel>();
            CreateMap<DemandModel, DemandFrontViewModel>();


            CreateMap<AccountRegisterModel, AccountBackModel>()
                .AfterMap( ( s, d ) => d.Identity = AccountIdentity.Unconfirmed )
                .AfterMap( ( s, d ) => d.Relieable.IsConfirmed = false )
                .ForPath( dest => dest.Sys.PasswordEncrypted,
                          opt => opt.MapFrom( src => encrypt.EncryptPassword( src.PlainPassword ) ) );
        }
    }
}
