using SiremGy.BLL.Interfaces.Common;
using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.BLL.Interfaces.Users
{
    public interface IUsersService : IBaseService
    {
        Task<BlResult<UserModel>> RegisterUser(UserModel UserModel);
        Task<BlResult<UserModel>> Login(UserModel UserModel);
        Task<BlResult<bool>> UserExists(UserModel UserModel);
    }
}
