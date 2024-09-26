using FluentValidation;
using MovieApp.Models.Dto;

namespace MovieApp.Models.Validators
{
    public class MovieDtoValidator : AbstractValidator<MovieDto>
    {
        public MovieDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(1);

            RuleFor(x => x.DurationInMinutes)
                .GreaterThan(0);


            RuleFor(x => x.PgInfo)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ReleaseDate)
                .NotNull();
        }
    }
}
