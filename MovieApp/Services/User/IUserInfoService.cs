using MovieApp.Models.Dto;

namespace MovieApp.Services.User
{
    public interface IUserInfoService
    {
        UserJwtInfoDto? UserJwtInfoDto { get; }
    }
}
