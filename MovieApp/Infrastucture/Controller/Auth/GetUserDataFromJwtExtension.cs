using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Models.Dto;
using System.Security.Claims;

namespace MovieApp.Infrastucture.Controller.Auth
{
    public static class GetUserDataFromJwtExtension
    {
        public static UserJwtInfoDto? GetUserDataFromJwt(this ClaimsPrincipal claimsPrincipal)
        {
            try
            {
                if (claimsPrincipal.Identity?.IsAuthenticated == false)
                {
                    
                }
                var userId = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
                var login = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "Login").Value;
                var isAdmin = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "IsAdmin").Value;
                var sessionId = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "SessionId").Value;
                return new UserJwtInfoDto(
                    Guid.Parse(userId),
                    login,
                    Convert.ToBoolean(isAdmin),
                    Guid.Parse(sessionId));
            }
            catch
            {
                return null;
            }
        }
    }
}
