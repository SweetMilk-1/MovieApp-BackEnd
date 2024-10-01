
using AutoMapper;
using MovieApp.Database.Entities;
using MovieApp.Models.Dto;

namespace MovieApp.Mappers
{
    public class UserMapperConfig : Profile
    {
        public UserMapperConfig() 
        {
            CreateMap<User, UserDto>();
        }
    }
}
