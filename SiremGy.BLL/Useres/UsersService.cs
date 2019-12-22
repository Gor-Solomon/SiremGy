using SiremGy.BLL.Interfaces.Token;
using SiremGy.DAL.Interfaces.Users;
using AutoMapper;
using System.Threading.Tasks;
using SiremGy.Models.Users;
using System.Security;
using SiremGy.BLL.Interfaces;
using SiremGy.DAL.Entities.Users;
using System;
using System.Text;
using SiremGy.BLL.Interfaces.Common;
using SiremGy.BLL.Exceptions;
using System.Net;
using System.Threading;
using SiremGy.BLL.Interfaces.Exceptions;

namespace SiremGy.BLL.Useres
{
    public class UserService : BaseService, IUsersService
    {
        private readonly IUsersRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public UserService(IUsersRepository authenticationRepository, IMapper mapper)
        {
            _authenticationRepository = authenticationRepository;
            _mapper = mapper;
        }

        public async Task<BlResult<UserModel>> Login(LoginModel loginModel)
        {
            var result = new BlResult<UserModel>();

            if (loginModel is null)
            {
                throw new ArgumentNullException(nameof(loginModel));
            }

            var entity = await _authenticationRepository.FirstOrDefaultAsync(x => x.Email == loginModel.Email.ToLower(Thread.CurrentThread.CurrentCulture));

            if (entity is null)
            {
                throw new InvalidEmailOrPasswordException();
            }

            verifyPasswordHash(loginModel.Password, entity.PasswordHash, entity.PasswordSalt, entity.CreationDate);
            result.Success(_mapper.Map<UserModel>(entity));

            return result;
        }

        private void verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt, DateTime creationDate)
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

        public async Task<BlResult<UserModel>> RegisterUser(RegisterModel registerModel)
        {
            byte[] passwordHash, PasswordSalt;
            var result = new BlResult<UserModel>();

            if (registerModel is null)
            {
                throw new ArgumentNullException(nameof(registerModel));
            }

            var emailExists = await UserExists(registerModel.Email);

            if (emailExists.Value)
            {
                string message =  string.Format("Sorry, Email '{0}' is already in use.", registerModel.Email);
                throw new UniqueConstraintException(message);
            }

            DateTime creationDate = DateTime.Now;
            passwordHash = createPasswordHash(creationDate, registerModel.Password, out PasswordSalt);

            var entity = _mapper.Map<UserEntity>(registerModel);
            entity.UniqueID = Guid.NewGuid();
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = PasswordSalt;
            entity.Email = entity.Email.ToLower(Thread.CurrentThread.CurrentCulture);
            entity.CreationDate = creationDate;

            await _authenticationRepository.AddAsync(entity);
            await _authenticationRepository.SaveChangesAsync();

            Array.Clear(entity.PasswordHash, 0, entity.PasswordHash.Length);
            Array.Clear(entity.PasswordSalt, 0, entity.PasswordSalt.Length);

            result.Success(_mapper.Map<UserModel>(entity));

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
                Array.Clear(input, 0, input.Length);
                Array.Clear(passwordArray, 0, passwordArray.Length);
                GC.Collect();
            }

            return result;
        }

        public async Task<BlResult<bool>> UserExists(string email)
        {
            var result = new BlResult<bool>();

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var exists = await _authenticationRepository.AnyAsync(x => x.Email == email.ToLower(Thread.CurrentThread.CurrentCulture));
            result.Success(exists);

            return result;
        }
    }
}
