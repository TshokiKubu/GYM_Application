using AutoMapper;
using GYMAPI.Models;
using GYMAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYMAPI.GymMapper
{
    public class GymMappings : Profile
    {
        public GymMappings()
        {
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();          
        }
    }
}
