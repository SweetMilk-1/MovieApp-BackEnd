using AutoMapper;
using MovieApp.Database.Entities;
using MovieApp.Models.Dto;

namespace MovieApp.Mappers
{
    public class ReviewMapperConfig : Profile
    {
        public ReviewMapperConfig()
        {
            CreateMap<ReviewDto, Review>()
                .ForMember(x => x.CreatedByUser, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LikeUsers, opt => opt.Ignore());
            CreateMap<Review, ReviewDto>();
        }
    }
}
