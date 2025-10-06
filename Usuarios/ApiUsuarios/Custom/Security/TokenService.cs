using ApiUsuarios.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiUsuarios.Custom.Security
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJWT(Usuarios user)
        {
            var userClaim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()),
                new Claim("userId",user.UsuarioId.ToString()),
                new Claim(ClaimTypes.Role, user.Rol.ToString()),
                new Claim("rol",user.Rol.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var securityCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtConfig = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: userClaim,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: securityCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }
    }
}
