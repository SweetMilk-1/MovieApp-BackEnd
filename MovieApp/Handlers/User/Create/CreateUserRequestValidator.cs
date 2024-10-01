using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;

namespace MovieApp.Handlers.User.Create
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly MovieAppDbContext _context;
        public CreateUserRequestValidator(MovieAppDbContext context)
        {
            _context = context;

            RuleFor(x => x.Login)
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(50)
                .Matches("^[0-9a-zA-Z_ ]*$")
                .MustAsync(IsLoginUnique) //NameRegexp
                .WithMessage("Пользователь с таким логином уже существует");

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(8)
                .Matches("^[0-9a-zA-Z_()!$%]*$"); //Password RegExp

            RuleFor(x => x.Email)
                .NotNull()
                .MinimumLength(6)
                .Matches("^[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\\.[a-zA-Z0-9_-]+$") //Email RegExp
                .MustAsync(IsEmailUnique)
                .WithMessage("Данный Email уже используется");
        }

        private async Task<bool> IsLoginUnique(string login, CancellationToken token)
        {
            return !await _context.Users.AnyAsync(x => x.Login == login);
        }

        private async Task<bool> IsEmailUnique(string email, CancellationToken token)
        {
            return !await _context.Users.AnyAsync(x => x.Email == email);
        }
    }
}