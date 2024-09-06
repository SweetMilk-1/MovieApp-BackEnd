using MovieApp.Models.Dto;
using MovieApp.Models.Dto.User;

namespace MovieApp.Services.User
{
    public class UserService : IUserService
    {
        public JwtTokensDto Authorize(AuthorizationUserDto authUser)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Guid RegisterUser(RegisterUserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
