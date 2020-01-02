using SiremGy.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.DAL.Interfaces.Users
{
    public interface IUsersRepository : IBaseRepository<UserEntity>
    {
        byte[] CreatePasswordHash(DateTime dateTime, string password, out byte[] passwordSalt)
        {
            passwordSalt = new byte[] {1,2,3};
            return passwordSalt;
        }
        void VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt, DateTime creationDate);
    }
}
