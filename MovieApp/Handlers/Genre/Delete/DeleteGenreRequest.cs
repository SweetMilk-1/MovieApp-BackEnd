using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Handlers.Genre.Delete
{
    public class DeleteGenreRequest : IRequest
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}
