using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiremGy.BLL.Interfaces.Token;
using SiremGy.BLL.Useres;
using SiremGy.DAL.EF;
using AutoMapper;
using System;
using SiremGy.Common.AutoMapper.Users;
using SiremGy.DAL.Interfaces.Users;
using SiremGy.DAL.DataAccess.Users;
using SiremGy.BLL.Tokens;

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
            services.AddScoped<IUsersService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
        }

        public void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        public void ConfigureAutoMapping(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile));
        }
    }
}
