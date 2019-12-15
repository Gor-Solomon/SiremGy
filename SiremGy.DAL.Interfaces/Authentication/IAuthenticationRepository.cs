using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.DAL.Interfaces.Authentication
{
    public interface IAuthenticationRepository
    {
        Task<UserModel> RegisterUser(UserModel userModel, SecureString password);
        Task<UserModel> Login(UserModel userModel);
        Task<bool> UserExists(UserModel userModel);
    }
}
