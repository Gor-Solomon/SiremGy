using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.BLL.Interfaces.Users
{
    public interface IUsersService
    {
        Task<List<UserModel>> GetUserModelsAsync();
        void Test();
    }
}
