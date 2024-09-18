using FluentValidation;
using MovieApp.Models.Dto;
using MovieApp.Models.DtoValidators;

namespace MovieApp.Handlers.Actors.Create
{
    public class CreateActorRequestValidator : AbstractValidator<CreateActorRequets>
    {
        public CreateActorRequestValidator(IValidator<ActorDto> validator) 
        {
            RuleFor(x => x)
                .SetValidator(validator);
        }
    }
}
