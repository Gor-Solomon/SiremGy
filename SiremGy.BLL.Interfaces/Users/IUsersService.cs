using SiremGy.BLL.Interfaces.Common;
using SiremGy.Models.Users;
using System.Threading.Tasks;

namespace SiremGy.BLL.Interfaces.Token
{
    public interface IUsersService : IBaseService
    {
        Task<BlResult<UserModel>> RegisterUser(RegisterModel UserModel);
        Task<BlResult<UserModel>> Login(LoginModel UserModel);
        Task<BlResult<bool>> UserExists(string email);
    }
}
