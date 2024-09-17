using FluentValidation;

namespace MovieApp.Handlers.Genre.GetList
{
    public class GetGenresListRequestValidator : AbstractValidator<GetGenresListRequest>
    {
        public GetGenresListRequestValidator() 
        {
            RuleFor(x => x.Page)
                .GreaterThan(0)
                .WithMessage("Номер страницы должен быть больше нуля");


            RuleFor(x => x.PerPage)
                .GreaterThan(10);
        }
    }
}
