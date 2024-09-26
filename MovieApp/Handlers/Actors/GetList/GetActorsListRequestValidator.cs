using FluentValidation;
using MovieApp.Models.Interfaces;

namespace MovieApp.Handlers.Actors.GetList
{
    public class GetActorsListRequestValidator : AbstractValidator<GetActorsListRequest>
    {
        public GetActorsListRequestValidator(IValidator<IPagedRequest> validator)
        {
            RuleFor(x => x)
                .SetValidator(validator);
        }
    }
}
