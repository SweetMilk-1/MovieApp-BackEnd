using FluentValidation;

namespace MovieApp.Handlers.Movie.UploadImage
{
    public class MovieUploadImageRequestValidator : AbstractValidator<MovieUploadImageRequest>
    {
        public MovieUploadImageRequestValidator(IValidator<IFormFile> validator) 
        { 
            RuleFor(x => x.File)
                .NotNull()
                .SetValidator(validator);
        }
    }
}
