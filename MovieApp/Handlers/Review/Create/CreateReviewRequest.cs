using MediatR;
using MovieApp.Models.Dto;


namespace MovieApp.Handlers.Review.Create
{
    public class CreateReviewRequest : ReviewDto, IRequest<Guid>
    {
        public CreateReviewRequest()
        {
            Id = null;
        }
    }
}
