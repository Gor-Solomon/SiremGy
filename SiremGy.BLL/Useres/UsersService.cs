using SiremGy.DAL.Interfaces.Users;
using AutoMapper;
using System.Threading.Tasks;
using SiremGy.DAL.Entities.Users;
using System;
using SiremGy.BLL.Interfaces.Common;
using System.Threading;
using SiremGy.BLL.Models.Users;
using SiremGy.Exceptions.BLLExceptions;
using SiremGy.BLL.Interfaces.Users;
using System.Collections.Generic;

namespace SiremGy.BLL.Useres
{
    public class UserService : BaseService, IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<BlResult<IEnumerable<UserModel>>> GetUsers()
        {
            var result = new BlResult<IEnumerable<UserModel>>();

            var entities = await _usersRepository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<UserModel>>(entities);

            result.Success(models);

            return result;
        }

        public async Task<BlResult<UserModel>> GetUser(int id)
        {
            var result = new BlResult<UserModel>();

            var entities = await _usersRepository.GetByIdAsync(id);
            var models = _mapper.Map<UserModel>(entities);

            result.Success(models);

            return result;
        }
        public async Task<BlResult<UserModel>> Login(LoginModel loginModel)
        {
            var result = new BlResult<UserModel>();

            if (loginModel is null)
            {
                throw new ArgumentNullException(nameof(loginModel));
            }

            var entity = await _usersRepository.FirstOrDefaultAsync(x => x.Email == loginModel.Email.ToLower(Thread.CurrentThread.CurrentCulture));

            if (entity is null)
            {
                throw new InvalidEmailOrPasswordException();
            }

            _usersRepository.VerifyPasswordHash(loginModel.Password, entity.PasswordHash, entity.PasswordSalt, entity.CreationDate);

            entity = await _usersRepository.GetByIdAsync(entity.Id);

            result.Success(_mapper.Map<UserModel>(entity));

            return result;
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
                string message = string.Format("Sorry, Email '{0}' is already in use.", registerModel.Email);
                throw new UniqueConstraintException(message);
            }

            DateTime creationDate = DateTime.Now;
            passwordHash = _usersRepository.CreatePasswordHash(creationDate, registerModel.Password, out PasswordSalt);

            var entity = _mapper.Map<UserEntity>(registerModel);
            entity.UniqueID = Guid.NewGuid();
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = PasswordSalt;
            entity.Email = entity.Email.ToLower(Thread.CurrentThread.CurrentCulture);
            entity.CreationDate = creationDate;

            _usersRepository.Add(entity);
            await _usersRepository.SaveChangesAsync();

            Array.Clear(entity.PasswordHash, 0, entity.PasswordHash.Length);
            Array.Clear(entity.PasswordSalt, 0, entity.PasswordSalt.Length);

            result.Success(_mapper.Map<UserModel>(entity));

            return result;
        }

        public async Task<BlResult<bool>> UserExists(string email)
        {
            var result = new BlResult<bool>();

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var exists = await _usersRepository.AnyAsync(x => x.Email == email.ToLower(Thread.CurrentThread.CurrentCulture));
            result.Success(exists);

            return result;
        }
    }
}
