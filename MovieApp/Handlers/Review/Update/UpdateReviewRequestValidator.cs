using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Review.Update
{
    public class UpdateReviewRequestValidator : AbstractValidator<UpdateReviewRequest>
    {
        private readonly MovieAppDbContext _context;
        public UpdateReviewRequestValidator(MovieAppDbContext context, IValidator<ReviewDto> validator)
        {
            _context = context;
            RuleFor(x => x)
                .SetValidator(validator);
        }
    }
}
