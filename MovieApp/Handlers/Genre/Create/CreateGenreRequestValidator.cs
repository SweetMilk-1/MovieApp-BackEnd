using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;

namespace MovieApp.Handlers.Genre.Create
{
    public class CreateGenreRequestValidator : AbstractValidator<CreateGenreRequest>
    {
        private readonly MovieAppDbContext _context;
        public CreateGenreRequestValidator(MovieAppDbContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .MinimumLength(3)
                .Matches("^[a-zA-Zа-яА-Я ]*$")
                .WithMessage("Название может содержать только символы русского и латинского алфавита")
                .MustAsync(IsGenreNameUnique)
                .WithMessage("Жанр с таким название уже существует");
        }

        private async Task<bool> IsGenreNameUnique(string genreName, CancellationToken token)
        {
            return !await _context.Genres.AnyAsync(x => x.Name == genreName);
        }
    }
}
