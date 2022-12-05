using AutoMapper;
using Kirala.com.Entities.Dto_s.Address;
using Kirala.com.Entities.Dto_s.AutoMobileAdverts;
using Kirala.com.Entities.Dto_s.User;
using Kirala.com.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserRegisterDto, User>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<UserLoginDto, User>().ReverseMap();

            CreateMap<AutoMobileAdvertsDto, AutoMobile>().ReverseMap();
            CreateMap<AutoMobile, AutoMobileAdvertsCreateDto>().ReverseMap();
            CreateMap<AutoMobileAdvertsUpdateDto, AutoMobile>().ReverseMap();

            CreateMap<Address, AddressCreateDto>().ReverseMap();
            CreateMap<Address, AutoMobileAdvertsCreateDto>().ReverseMap()
                .ForMember(x => x.CityId, y => y.MapFrom(z => z.CityId))
                .ForMember(x => x.District, y => y.MapFrom(z => z.District));
            CreateMap<Address, AddressDto>().ReverseMap()
                .ForMember(x => x.CityId, y => y.MapFrom(z => z.CityId))
                .ForMember(x => x.District, y => y.MapFrom(z => z.District));

        }
    }
}
