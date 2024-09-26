using FluentValidation;
using MovieApp.Models.Interfaces;

namespace MovieApp.Handlers.Genre.GetList
{
    public class GetGenresListRequestValidator : AbstractValidator<GetGenresListRequest>
    {
        public GetGenresListRequestValidator(IValidator<IPagedRequest> validator) 
        {
            RuleFor(x => x)
                .SetValidator(validator);
        }
    }
}
