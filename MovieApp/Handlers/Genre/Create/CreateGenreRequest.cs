using MediatR;

namespace MovieApp.Handlers.Genre.Create
{
    public class CreateGenreRequest : IRequest
    {
        public string Name { get; set; }
    }
}
