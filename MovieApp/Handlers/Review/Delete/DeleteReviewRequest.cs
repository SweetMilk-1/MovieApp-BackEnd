using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Handlers.Review.Delete
{
    public class DeleteReviewRequest : IRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}
