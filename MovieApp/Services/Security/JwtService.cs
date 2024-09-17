using Microsoft.IdentityModel.Tokens;
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

        public string CreateAccessToken(string login, bool isAdmin, Guid sessionId)
        {
            var claims = new List<Claim>
            {
                new Claim("Login", login),
                new Claim("IsAdmin", isAdmin.ToString()),
                new Claim("SessionId", sessionId.ToString())
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
