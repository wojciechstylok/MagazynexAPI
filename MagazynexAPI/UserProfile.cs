using AutoMapper;
using MagazynexAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynexAPI
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserLogInDto>()
                .ForMember(u => u.Id, map => map.MapFrom(user => user.Id))
                .ForMember(u => u.Firstname, map => map.MapFrom(user => user.Firstname));

            CreateMap<User, UserGetInfoDto>()
                .ForMember(u => u.Id, map => map.MapFrom(user => user.Id))
                .ForMember(u => u.Firstname, map => map.MapFrom(user => user.Firstname))
                .ForMember(u => u.Lastname, map => map.MapFrom(user => user.Lastname))
                .ForMember(u => u.Login, map => map.MapFrom(user => user.Login));
        }
    }
}
