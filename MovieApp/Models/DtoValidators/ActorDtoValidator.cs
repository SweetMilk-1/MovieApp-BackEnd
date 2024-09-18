using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Models.Dto;

namespace MovieApp.Models.DtoValidators
{
    public class ActorDtoValidator : AbstractValidator<ActorDto>
    {
        private readonly MovieAppDbContext _dbContext;

        public ActorDtoValidator(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .Matches("^[a-zA-Zа-яА-Я .,-]*$")
                .WithMessage("Имя актера может содержать только буквы русского и латинского авфавита, точки, запятой, дефиса и пробела");

            RuleFor(x => x.Bio)
                .MaximumLength(1000);

            RuleFor(x => x)
                .MustAsync(IsNameUnique)
                .WithMessage("Имя актера должно быть уникальным");
        }

        private async Task<bool> IsNameUnique(ActorDto dto, CancellationToken token)
        {
            return dto.Id == null 
                ? !await _dbContext.Actors.AnyAsync(x => x.Name == dto.Name)
                : !await _dbContext.Actors.AnyAsync(x => x.Name == dto.Name && x.Id != dto.Id);
        }
    }
}
