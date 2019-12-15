using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiremGy.BLL.Interfaces.Users;
using SiremGy.BLL.Useres;
using SiremGy.DAL.EF;
using AutoMapper;
using System;
using SiremGy.Common.AutoMapper.Users;
using SiremGy.DAL.Interfaces.Authentication;
using SiremGy.DAL.DataAccess.Authentication;

namespace SiremGy.Common
{
    public class DependenciesResolver
    {
        private readonly IConfiguration _configuration;

        public DependenciesResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureDbContext(IServiceCollection services)
        {
            string connectionString = _configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<SiremGyDbContext>(options => options.UseSqlite(connectionString));
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IUsersService, UserService>();
        }

        public void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
        }

        public void ConfigureAutoMapping(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile));
        }
    }
}
