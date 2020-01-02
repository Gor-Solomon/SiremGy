using Microsoft.IdentityModel.Tokens;
using SiremGy.BLL.Interfaces.Tokens;
using SiremGy.BLL.Models.Users;
using System;
using System.IdentityModel.Tokens.Jwt;
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
                    new Claim(ClaimTypes.NameIdentifier, userModel.UniqueID.ToString()),
                    new Claim(ClaimTypes.Name, userModel.Email),
                    new Claim(ClaimTypes.GivenName, userModel.UserName),
                    new Claim(ClaimTypes.Gender, userModel.UserDetail.Gender),
                    new Claim(ClaimTypes.MobilePhone, userModel.MobileNumber),
                    new Claim(ClaimTypes.Country, userModel.UserDetail.Country),
                    new Claim(ClaimTypes.StreetAddress, userModel.UserDetail.Address),
                    new Claim(ClaimTypes.DateOfBirth, userModel.UserDetail.Birthday.ToString()),
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
