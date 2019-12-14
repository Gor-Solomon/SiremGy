using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiremGy.DAL.DataAccess;
using SiremGy.BLL.Interfaces.Users;
using SiremGy.BLL.Useres;

namespace SiremGy.Common
{
    public class DependenciesResolver
    {
        private readonly IConfiguration _configuration;
        private readonly string _ConnectionString;

        public DependenciesResolver(IConfiguration configuration)
        {
            _configuration = configuration;
            _ConnectionString = configuration.GetConnectionString("DatabaseConnection");
        }
        public void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<SiremGyDbContext>(options => options.UseSqlite(_ConnectionString));
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUsersService, UserService>();
        }
    }
}
