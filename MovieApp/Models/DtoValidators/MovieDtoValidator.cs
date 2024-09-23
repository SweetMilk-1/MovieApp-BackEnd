using FluentValidation;
using MovieApp.Models.Dto;

namespace MovieApp.Models.DtoValidators
{
    public class MovieDtoValidator : AbstractValidator<MovieDto>
    {
        public MovieDtoValidator() {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1);

            RuleFor(x => x.PgInfo)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ReleaseDate)
                .NotNull();
        }
    }
}
