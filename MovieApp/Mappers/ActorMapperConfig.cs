using AutoMapper;
using MovieApp.Database.Entities;
using MovieApp.Models.Common;
using MovieApp.Models.Dto;

namespace MovieApp.Mappers
{
    public class ActorMapperConfig : Profile
    {
        public ActorMapperConfig() 
        {
            CreateMap<ActorDto, Actor>()
                .ForMember(d => d.Id, opt => opt.Ignore());
            CreateMap<Actor, ActorDto>();
            CreateMap<Actor, DictionaryItemDto>();
        }
    }
}
