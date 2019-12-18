using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace SiremGy.BLL.Interfaces.Token
{
    public interface ITokenService : IBaseService
    {
        string GenerateAuthenticationToken(UserModel userModel, string symetricKey);
    }
}
