using FluentValidation;

namespace MovieApp.Handlers.User.UploadImage
{
    public class UserUploadImageRequestValidator : AbstractValidator<UserUploadImageRequest>
    {
        public UserUploadImageRequestValidator(IValidator<IFormFile> validator) 
        { 
            RuleFor(x => x.File)
                .NotNull()
                .SetValidator(validator);
        }
    }
}
