using SiremGy.DAL.DataAccess;
using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SiremGy.BLL.Interfaces.Users;

namespace SiremGy.BLL.Useres
{
    public class UserService : IUsersService
    {
        private readonly SiremGyDbContext _siremGyDbContext;

        public UserService(SiremGyDbContext siremGyDbContext)
        {
            this._siremGyDbContext = siremGyDbContext;
        }

        public async Task<List<UserModel>> GetUserModelsAsync()
        {
            return await _siremGyDbContext.Users.ToListAsync();
        }
    }
}
