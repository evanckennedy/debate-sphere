using DebateSphere.Models.DTOs;
using DebateSphere.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateSphere.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserReadDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();

            CreateMap<Debate, DebateCreateDTO>().ReverseMap();
            CreateMap<Debate, DebateListDTO>().ReverseMap();
            CreateMap<Debate, DebateReadDTO>().ReverseMap();
            CreateMap<Debate, DebateUpdateDTO>().ReverseMap();

            CreateMap<Argument, ArgumentCreateDTO>().ReverseMap();
            CreateMap<Argument, ArgumentListDTO>().ReverseMap();
            CreateMap<Argument, ArgumentReadDTO>().ReverseMap();
            CreateMap<Argument, ArgumentUpdateDTO>().ReverseMap();

            CreateMap<Vote, VoteCreateDTO>().ReverseMap();
            CreateMap<Vote, VoteListDTO>().ReverseMap();
        }
    }
}
