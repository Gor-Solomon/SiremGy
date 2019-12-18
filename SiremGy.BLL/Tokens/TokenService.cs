using Microsoft.IdentityModel.Tokens;
using SiremGy.BLL.Interfaces.Token;
using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace SiremGy.BLL.Tokens
{
    public class TokenService : BaseService, ITokenService
    {
        public string GenerateAuthenticationToken(UserModel userModel, string symetricKey)
        {
            Claim[] claims = new[]
           {
                    new Claim(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
                    new Claim(ClaimTypes.Name, userModel.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(symetricKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var generatedToken = tokenHandler.WriteToken(token);

            return generatedToken;
        }
    }
}
