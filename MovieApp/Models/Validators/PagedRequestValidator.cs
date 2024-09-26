using FluentValidation;
using MovieApp.Models.Interfaces;

namespace MovieApp.Models.Validators
{
    public class PagedRequestValidator : AbstractValidator<IPagedRequest>
    {
        public PagedRequestValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Номер страницы должен быть больше нуля");


            RuleFor(x => x.PerPage)
                .GreaterThan(0)
                .WithMessage("Количество записей на странице должно быть больше нуля");
        }
    }
}
