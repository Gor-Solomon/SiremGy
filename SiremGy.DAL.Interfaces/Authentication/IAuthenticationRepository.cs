using SiremGy.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.DAL.Interfaces.Authentication
{
    public interface IAuthenticationRepository : IBaseRepository<UserEntity>
    {
     
    }
}
