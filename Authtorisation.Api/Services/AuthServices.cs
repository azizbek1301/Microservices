using Authtorisation.Api.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authtorisation.Api.Services
{
    public class AuthServices
    {
        public string GenerateToken(UserDTO userDTO)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asosiyUser711w15ed16516w6e51de65f1ef1e6f51ef51"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userDTO.UserName),
                new Claim(ClaimTypes.Role, userDTO.Role)
            };

            var token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
