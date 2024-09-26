using FluentValidation;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Movie.Update
{
    public class UpdateMovieRequestValidator : AbstractValidator<UpdateMovieRequest>
    {
        public UpdateMovieRequestValidator(IValidator<MovieDto> validator) 
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x)
                .SetValidator(validator);
        }
    }
}
