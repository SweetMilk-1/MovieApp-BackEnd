using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;

namespace MovieApp.Handlers.Genre.Update
{
    public class UpdateGenreRequestValidator : AbstractValidator<UpdateGenreRequest>
    {
        private readonly MovieAppDbContext _context;
        public UpdateGenreRequestValidator(MovieAppDbContext context)
        {
            _context = context;
            RuleFor(x => x.Id)
                .NotNull();

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .Matches("^[a-zA-Zа-яА-Я ]*$")
                .WithMessage("Название может содержать только символы русского и латинского алфавита");

            RuleFor(x => x)
                .MustAsync(IsGenreNameUnique)
                .WithMessage("Жанр с таким название уже существует");
        }

        private async Task<bool> IsGenreNameUnique(UpdateGenreRequest request, CancellationToken token)
        {
            return !await _context.Genres.AnyAsync(x => x.Name == request.Name && x.Id != request.Id);
        }
    }
}
