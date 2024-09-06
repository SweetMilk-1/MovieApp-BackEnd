using MovieApp.Models.Dto;
using MovieApp.Models.Dto.User;

namespace MovieApp.Services.User
{
    public interface IUserService
    {
        UserDto GetUserById(Guid Id);
        Guid RegisterUser(RegisterUserDto user);
        JwtTokensDto Authorize(AuthorizationUserDto authUser);


    }
}
