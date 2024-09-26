using FluentValidation;
using MovieApp.Models.Interfaces;

namespace MovieApp.Handlers.Movie.GetList
{
    public class GetMoviesListRequestValidator : AbstractValidator<GetMoviesListRequest>
    {
        public GetMoviesListRequestValidator(IValidator<IPagedRequest> validator)
        {
            RuleFor(x => x)
                .SetValidator(validator);
        }
    }
}
