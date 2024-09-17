using FluentValidation;

namespace MovieApp.Handlers.User.Registeration
{
    public class RegistrationUserRequestValidator : AbstractValidator<RegistrationUserRequest>
    {
        private readonly MovieAppDbContext context;
        public RegistrationUserRequestValidator(MovieAppDbContext context)
        {
            RuleFor(x => x.Login)
                .NotNull()
                .MinimumLength(6)
                .MaximumLength(50)
                .Matches("^[0-9a-zA-Z_ ]*$")
                .Must(IsLoginUnique); //NameRegexp

            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(6)
                .Matches("^[0-9a-zA-Z_()!$%]*$"); //Password RegExp

            RuleFor(x => x.Email)
                .NotNull()
                .MinimumLength(6)
                .Matches("^[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\\.[a-zA-Z0-9_-]+$") //Email RegExp
                .Must(IsEmailUnique);
        }

        private bool IsLoginUnique(string arg)
        {
            throw new NotImplementedException();
        }

        private bool IsEmailUnique(string arg)
        {
            throw new NotImplementedException();
        }
    }
}