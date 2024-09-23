using Microsoft.IdentityModel.Tokens;
using MovieApp.Models.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieApp.Services.Security
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateAccessToken(UserJwtInfoDto userJwtInfo)
        {
            var claims = new List<Claim>
            {
                new Claim("UserId", userJwtInfo.UserId.ToString()),
                new Claim("Login", userJwtInfo.Login),
                new Claim("IsAdmin", userJwtInfo.IsAdmin.ToString()),
                new Claim("SessionId", userJwtInfo.sessionId.ToString())
            };

            var expiredTime = _configuration.GetValue<int>("Security:Jwt:AccessExpiredTime");
            var now = DateTime.UtcNow;

            return CreateToken(claims, expiredTime, now);
        }

        public string CreateRefreshToken(Guid sessionId)
        {
            var claims = new List<Claim>
            {
                new Claim("SessionId", sessionId.ToString())
            };


            var expiredTime = _configuration.GetValue<int>("Security:Jwt:RefreshExpiredTime");
            var now = DateTime.UtcNow;

            return CreateToken(claims, expiredTime, now);
        }

        private string CreateToken(List<Claim> claims, int expiredTime, DateTime now)
        {
            var issuer = _configuration.GetValue<string>("Security:Jwt:Issuer");
            var audience = _configuration.GetValue<string>("Security:Jwt:Audience");
            var key = _configuration.GetValue<string>("Security:Jwt:Key");

            var symmetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(expiredTime)),
                signingCredentials: signingCredentials
                );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
