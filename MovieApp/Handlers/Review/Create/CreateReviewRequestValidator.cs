using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Review.Create
{
    public class CreateReviewRequestValidator : AbstractValidator<CreateReviewRequest>
    {
        private readonly MovieAppDbContext _context;
        private readonly IValidator<ReviewDto> _validator;
        public CreateReviewRequestValidator(MovieAppDbContext context, IValidator<ReviewDto> validator)
        {
            _context = context;
            _validator = validator;

            RuleFor(x => x)
                .SetValidator(validator);

            RuleFor(x => x.MovieId)
                .MustAsync(IsMovieExist)
                .WithMessage(x => $"Фильма {x.MovieId} не существует");
        }

        private async Task<bool> IsMovieExist(Guid movieId, CancellationToken token)
        {
            return await _context.Movies.AnyAsync(x => x.Id == movieId);
        }
    }
}
