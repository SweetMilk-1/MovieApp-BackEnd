using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using MovieApp.Infrastucture.Exceptions;
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
                new Claim("SessionId", userJwtInfo.SessionId.ToString())
            };

            var expiredTime = _configuration.GetValue<int>("Security:Jwt:AccessExpiredTime");

            return CreateToken(claims, expiredTime);
        }

        public string CreateRefreshToken(Guid sessionId)
        {
            var claims = new List<Claim>
            {
                new Claim("SessionId", sessionId.ToString())
            };


            var expiredTime = _configuration.GetValue<int>("Security:Jwt:RefreshExpiredTime");

            return CreateToken(claims, expiredTime);
        }

        public Guid GetSessionIdFromRefreshToken(string refreshToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();

                var jwtValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = _configuration.GetValue<string>("Security:Jwt:Issuer"),
                    ValidateAudience = true,
                    ValidAudience = _configuration.GetValue<string>("Security:Jwt:Audience"),
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                   _configuration.GetValue<string>("Security:Jwt:Key"))),
                    ValidateIssuerSigningKey = true,
                };

                var claims = handler.ValidateToken(refreshToken, jwtValidationParameters, out SecurityToken securityToken);
                var sessionId = claims?.FindFirstValue("SessionId");

                return sessionId != null ? Guid.Parse(sessionId) : throw new Exception();
            }
            catch (Exception ex)
            {
                throw new BadRequestException("Некорректный токен. Необходима повторная авторизация");
            }
        }

        private string CreateToken(List<Claim> claims, int expiredTime)
        {
            var issuer = _configuration.GetValue<string>("Security:Jwt:Issuer");
            var audience = _configuration.GetValue<string>("Security:Jwt:Audience");
            var key = _configuration.GetValue<string>("Security:Jwt:Key");

            var symmetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(expiredTime)),
                signingCredentials: signingCredentials,
                claims: claims);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
