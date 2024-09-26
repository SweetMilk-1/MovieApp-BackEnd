using Microsoft.AspNetCore.Http;
using MovieApp.Infrastucture.Controller.Auth;
using MovieApp.Models.Dto;

namespace MovieApp.Services.User
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserInfoService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserJwtInfoDto? UserJwtInfoDto => _httpContextAccessor.HttpContext?.User?.GetUserDataFromJwt();
    }
}
