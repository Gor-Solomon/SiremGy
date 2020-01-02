using SiremGy.BLL.Interfaces.Common;
using SiremGy.BLL.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiremGy.BLL.Interfaces.Users
{
    public interface IUsersService : IBaseService
    {
        Task<BlResult<UserModel>> RegisterUser(RegisterModel UserModel);
        Task<BlResult<UserModel>> Login(LoginModel UserModel);
        Task<BlResult<bool>> UserExists(string email);
        Task<BlResult<IEnumerable<UserModel>>> GetUsers();
        Task<BlResult<UserModel>> GetUser(int id);
    }
}
