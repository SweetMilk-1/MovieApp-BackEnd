using MediatR;

namespace MovieApp.Handlers.User.Registeration
{
    public class RegistrationUserRequest : IRequest<RegistrationUserResponse>
    {
        public string Email { get; set; } //не должно быть других челов с таким же логином
        public string Login { get; set; } //не должно быть других челов с таким же email
        public string Password { get; set; }
    }


}
