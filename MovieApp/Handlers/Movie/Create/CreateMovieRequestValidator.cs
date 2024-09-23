using FluentValidation;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Movie.Create
{
    public class CreateMovieRequestValidator : AbstractValidator<CreateMovieRequest>
    {
        public CreateMovieRequestValidator(IValidator<MovieDto> validator)
        {
            RuleFor(x => x)
                .SetValidator(validator);
        }
    }
}
