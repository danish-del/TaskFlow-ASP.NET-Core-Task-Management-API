using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskFlow.Insfrastructure.Identity;

namespace TaskFlow.Insfrastructure.Service
{
    public class JwtService
    {
        private readonly string _key;
        public JwtService(IConfiguration config)
        {
            _key = config["JWT:Key"] ??  throw new Exception("Jwt not found!");
        }
        public string GenerateToken(AppUser user)
        {
            var Claim = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName
                ?? "")
            };
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.
                HmacSha256);
            var token = new JwtSecurityToken(
                claims: Claim,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
