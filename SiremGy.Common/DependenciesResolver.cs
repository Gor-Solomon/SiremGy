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
        private readonly string _ConnectionString = "Data Source=SiremGy.db";

        public DependenciesResolver()
        {
        }
        public void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<SiremGyDbContext>(options => options.UseSqlite(_ConnectionString));
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUsersService, UserService>();
        }

       // PUBLIC DBCONTEXTOPTIONSBUILDER<SIREMGYDBCONTEXT> GETDBCONTEXTOPTIONSBUILDER()
       //{
       //     VAR BUILDER = NEW DBCONTEXTOPTIONSBUILDER<SIREMGYDBCONTEXT>();
       //     BUILDER.USESQLITE(_CONNECTIONSTRING);
       //     RETURN NEW SIREMGYDBCONTEXT(BUILDER.OPTIONS);
       // }
    }
}
