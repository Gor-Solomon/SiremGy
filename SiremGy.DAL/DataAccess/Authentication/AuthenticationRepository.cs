using Microsoft.EntityFrameworkCore;
using SiremGy.DAL.EF;
using SiremGy.DAL.Entities.Users;
using SiremGy.DAL.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.DAL.DataAccess.Authentication
{
    public class AuthenticationRepository : BaseRepository<UserEntity, SiremGyDbContext>, IAuthenticationRepository
    {
        public AuthenticationRepository(SiremGyDbContext siremGyDbContext) : base(siremGyDbContext)
        {
        }
    }
}
