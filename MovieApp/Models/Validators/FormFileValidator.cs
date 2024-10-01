using FluentValidation;

namespace MovieApp.Models.Validators
{
    public class FormFileValidator : AbstractValidator<IFormFile>
    {
        private const int MAX_SIZE = 1024 * 1024 * 2; //2 MB

        private string[] _permittedExtensions = { ".jpg", ".png", ".webp", ".jfif" }; 
        public FormFileValidator() 
        {
            RuleFor(x => x.Length)
                .LessThanOrEqualTo(MAX_SIZE)
                .WithMessage("Файл должен весить не больше 2 Мб");

            RuleFor(x => x.FileName)
                .Must(IsExtensionValid)
                .WithMessage("Файл имеет недопустимое расширение");
        }

        private bool IsExtensionValid(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            return !string.IsNullOrEmpty(ext) && _permittedExtensions.Contains(ext);
        }
    }
}
