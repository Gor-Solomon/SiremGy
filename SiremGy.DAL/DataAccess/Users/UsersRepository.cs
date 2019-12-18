using SiremGy.DAL.EF;
using SiremGy.DAL.Entities.Users;
using SiremGy.DAL.Interfaces.Users;

namespace SiremGy.DAL.DataAccess.Users
{
    public class UsersRepository : BaseRepository<UserEntity, SiremGyDbContext>, IUsersRepository
    {
        public UsersRepository(SiremGyDbContext siremGyDbContext) : base(siremGyDbContext)
        {
        }
    }
}
