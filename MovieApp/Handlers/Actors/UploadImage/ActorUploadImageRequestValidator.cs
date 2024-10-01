using FluentValidation;

namespace MovieApp.Handlers.Actors.UploadImage
{
    public class ActorUploadImageRequestValidator : AbstractValidator<ActorUploadImageRequest>
    {
        public ActorUploadImageRequestValidator(IValidator<IFormFile> validator) 
        { 
            RuleFor(x => x.File)
                .NotNull()
                .SetValidator(validator);
        }
    }
}
