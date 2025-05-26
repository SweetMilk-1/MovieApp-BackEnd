using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Review.Update
{
    public class UpdateReviewRequest :ReviewDto, IRequest
    {

    }
}
