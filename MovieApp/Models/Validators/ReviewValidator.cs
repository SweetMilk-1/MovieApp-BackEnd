using FluentValidation;
using MovieApp.Models.Dto;

namespace MovieApp.Models.Validators
{
    public class ReviewValidator : AbstractValidator<ReviewDto>
    {
        public ReviewValidator() {

            RuleFor(x => x.Grade)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(5)
                .WithMessage("Оценка должна быть от 1 до 5");
        }
    }
}
