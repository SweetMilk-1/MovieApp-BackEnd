using FluentValidation;

namespace MovieApp.Handlers.Actors.GetList
{
    public class GetActorsListRequestValidator : AbstractValidator<GetActorsListRequest>
    {
        public GetActorsListRequestValidator()
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
