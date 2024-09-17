using AutoMapper;
using MovieApp.Database.Entities;
using MovieApp.Models;

namespace MovieApp.Mappers
{
    public class GenreMapperConfig : Profile
    {
        public GenreMapperConfig() 
        {
            CreateMap<Genre, DictionaryItemDto>();
        }
    }
}
