using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiremGy.BLL.Interfaces.Tokens;
using SiremGy.BLL.Useres;
using SiremGy.DAL.EF;
using AutoMapper;
using SiremGy.Common.AutoMapper.Users;
using SiremGy.DAL.Interfaces.Users;
using SiremGy.DAL.DataAccess.Users;
using SiremGy.BLL.Tokens;
using SiremGy.Common.AutoMapper.Photos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SiremGy.BLL.Interfaces.Users;

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

            DbContextOptionsBuilder<SiremGyDbContext> dbContextOptionsBuilder = null;
            services.AddDbContext<SiremGyDbContext>(options => options.UseSqlite(connectionString));

            dbContextOptionsBuilder = new DbContextOptionsBuilder<SiremGyDbContext>();
            dbContextOptionsBuilder.UseSqlite(connectionString);

            using (SiremGyDbContext siremGyDbContext = new SiremGyDbContext(dbContextOptionsBuilder.Options))
            {
                siremGyDbContext.Database.Migrate();
                siremGyDbContext.Initialize();
            }
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

        public void AddAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                });
        }

        public void ConfigureAutoMapping(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperUserProfile), typeof(AutoMapperPhotoProfile));
        }
    }
}
