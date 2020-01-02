using SiremGy.BLL.Models.Users;

namespace SiremGy.BLL.Interfaces.Tokens
{
    public interface ITokenService : IBaseService
    {
        string GenerateAuthenticationToken(UserModel userModel, string symetricKey);
    }
}
