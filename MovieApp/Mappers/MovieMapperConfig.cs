using AutoMapper;
using MovieApp.Database.Entities;
using MovieApp.Models.Dto;

namespace MovieApp.Mappers
{
    public class MovieMapperConfig : Profile
    {
        public MovieMapperConfig() {
            CreateMap<Movie, MovieDto>();

            CreateMap<MovieDto, Movie>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.CreatedByUserId, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.Genres, opt => opt.Ignore())
                .ForMember(x => x.Actors, opt => opt.Ignore());

            CreateMap<Movie, MovieItemDto>();
        }
    }
}
