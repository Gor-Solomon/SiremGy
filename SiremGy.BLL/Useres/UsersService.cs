using SiremGy.BLL.Interfaces.Users;
using SiremGy.DAL.Interfaces.Authentication;
using AutoMapper;
using System.Threading.Tasks;
using SiremGy.Models.Users;
using System.Security;
using SiremGy.BLL.Interfaces;
using SiremGy.DAL.Entities.Users;
using System;
using System.Text;
using SiremGy.BLL.Interfaces.Common;
using SiremGy.BLL.Common;

namespace SiremGy.BLL.Useres
{
    public class UserService : BaseService<IAuthenticationRepository>, IUsersService
    {

        public UserService(IAuthenticationRepository authenticationRepository, IMapper mapper) : base(authenticationRepository, mapper)
        {
        }

        public Task<BlResult<UserModel>> Login(UserModel UserModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<BlResult<UserModel>> RegisterUser(UserModel UserModel)
        {
            byte[] passwordHash, PasswordSalt;
            var result = new BlResult<UserModel>();

            try
            {
                if (UserModel is null)
                {
                    throw CreateException(Constants.Errors.ArgumentNull);
                }

                UserModel.CreationDate = DateTime.Now;
                passwordHash = createPasswordHash(UserModel.CreationDate, UserModel.Password, out PasswordSalt);

                var entity = _mapper.Map<UserEntity>(UserModel);
                entity.PasswordHash = passwordHash;
                entity.PasswordSalt = PasswordSalt;

                await _repository.AddAsync(entity);
                await _repository.SaveChangesAsync();

                Array.Clear(entity.PasswordHash, 0, entity.PasswordHash.Length);
                Array.Clear(entity.PasswordSalt, 0, entity.PasswordSalt.Length);

                result.Success(_mapper.Map<UserModel>(entity));
            }
            catch(CustomException ex)
            {
                result.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                result.Fail(Constants.Errors.GenericError);
            }

            return result;
        }

        private byte[] createPasswordHash(DateTime dateTime, string password, out byte[] passwordSalt)
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
                Array.Clear(input,0,input.Length);
                Array.Clear(passwordArray, 0, passwordArray.Length);
                GC.Collect();
            }

            return result;
        }

        public Task<BlResult<bool>> UserExists(UserModel UserModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
