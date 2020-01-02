using Microsoft.EntityFrameworkCore;
using SiremGy.DAL.EF;
using SiremGy.DAL.Entities.Users;
using SiremGy.DAL.Interfaces.Users;
using SiremGy.Exceptions.BLLExceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SiremGy.DAL.DataAccess.Users
{
    public class UsersRepository : BaseRepository<UserEntity, SiremGyDbContext>, IUsersRepository
    {
        public UsersRepository(SiremGyDbContext siremGyDbContext) : base(siremGyDbContext)
        {
        }

        public byte[] CreatePasswordHash(DateTime dateTime, string password, out byte[] passwordSalt)
        {
            byte[] result = null;
            byte[] dateArray = BitConverter.GetBytes(dateTime.Ticks);
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);
            byte[] input = new byte[dateArray.Length + passwordArray.Length];

            dateArray.CopyTo(input, 0);
            passwordArray.CopyTo(input, dateArray.Length);

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                result = hmac.ComputeHash(input);
                Array.Clear(input, 0, input.Length);
                Array.Clear(passwordArray, 0, passwordArray.Length);
                GC.Collect();
            }

            return result;
        }

        public void VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt, DateTime creationDate)
        {
            byte[] dateArray = BitConverter.GetBytes(creationDate.Ticks);
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);
            byte[] input = new byte[dateArray.Length + passwordArray.Length];

            dateArray.CopyTo(input, 0);
            passwordArray.CopyTo(input, dateArray.Length);

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var generatedHash = hmac.ComputeHash(input);

                for (int i = 0; i < generatedHash.Length; i++)
                {
                    if (generatedHash[i] != passwordHash[i])
                    {
                        throw new InvalidEmailOrPasswordException();
                    }
                }
            }
        }

        public async override Task<UserEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Users
                         .Include(i => i.UserDetail).ThenInclude(i => i.Photos)
                         .Include(i => i.UserDetail).ThenInclude(i => i.Photo)
                         .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async override Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
