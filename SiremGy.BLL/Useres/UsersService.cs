using SiremGy.DAL.DataAccess;
using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SiremGy.BLL.Interfaces.Users;
using SiremGy.DAL.EF;
using SiremGy.DAL.DataAccess.Authentication;
using SiremGy.DAL.Interfaces.Authentication;

namespace SiremGy.BLL.Useres
{
    public class UserService : IUsersService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public UserService(IAuthenticationRepository authenticationRepository)
        {
            this._authenticationRepository = authenticationRepository;
        }

        public async Task<List<UserModel>> GetUserModelsAsync()
        {
            throw new NotImplementedException();
        }

        public async void Test()
        {
            await _authenticationRepository.RegisterUser(new UserModel() { CreationDate = DateTime.Now, Email = "adwawdawd", Id = 3, UserName = "panos" }, new System.Security.SecureString());
        }
    }
}
