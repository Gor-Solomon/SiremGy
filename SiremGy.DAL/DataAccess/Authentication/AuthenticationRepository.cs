using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiremGy.DAL.EF;
using SiremGy.DAL.Entities.Users;
using SiremGy.DAL.Interfaces.Authentication;
using SiremGy.Models.Users;
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
        public AuthenticationRepository(SiremGyDbContext siremGyDbContext, IMapper mapper) : base(siremGyDbContext, mapper)
        {
        }
        public Task<UserModel> Login(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> RegisterUser(UserModel userModel, SecureString password)
        {
            await  Task.Run(() => { });
            var x = _mapper.Map<UserModel, UserEntity>(userModel);
            return _mapper.Map<UserModel>(userModel);
        }

        public Task<bool> UserExists(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        /// <exception cref="System.NotImplementedException">For security reasons, it's forbiden to get all the users.</exception>
        public override Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <exception cref="System.NotImplementedException">For security reasons, it's forbiden to get all the users.</exception>
        public override Task<IEnumerable<UserEntity>> GetAllAsync(Expression<Func<UserEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
