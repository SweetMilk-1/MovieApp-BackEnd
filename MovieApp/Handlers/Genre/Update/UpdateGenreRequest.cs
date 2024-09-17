using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Handlers.Genre.Update
{
    public class UpdateGenreRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
