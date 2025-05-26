using FluentValidation;
using MovieApp.Handlers.Genre.GetList;
using MovieApp.Models.Interfaces;

namespace MovieApp.Handlers.Review.GetList
{
    public class GetReviewsRequestValidator : AbstractValidator<GetReviewsRequest>
    {
        public GetReviewsRequestValidator(IValidator<IPagedRequest> validator)
        {
            RuleFor(x => x)
                .SetValidator(validator);

            RuleFor(x => x.MovieId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Идентификатор фильма обязателен");

            RuleFor(x => x.Sort)
                .Must(isSortWayValid)
                .WithMessage("Некорректный способ сортировки");
        }

        private bool isSortWayValid(string? sortWay)
        {
            return string.IsNullOrEmpty(sortWay)
                || sortWay == ReviewSortWay.ByGradeAsc
                || sortWay == ReviewSortWay.ByGradeDesc
                || sortWay == ReviewSortWay.ByCreateDateAsc
                || sortWay == ReviewSortWay.ByCreateDateDesc;
        }
    }
}
