using FluentValidation;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Actors.Update
{
    public class UpdateActorRequestValidator : AbstractValidator<UpdateActorRequest>
    {
        public UpdateActorRequestValidator(IValidator<ActorDto> validator) 
        { 
            RuleFor(x => x)
                .SetValidator(validator);

            RuleFor(x => x.Id)
                .NotNull();
        }
    }
}
