using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SiremGy.BLL.Interfaces.Exceptions;
using SiremGy.Common;
using System.Text;

namespace SiremGy.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DependenciesResolver = new DependenciesResolver(configuration);
        }

        public IConfiguration Configuration { get; }
        public DependenciesResolver DependenciesResolver { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            DependenciesResolver.ConfigureDbContext(services);
            DependenciesResolver.ConfigureAutoMapping(services);
            DependenciesResolver.RegisterRepositories(services);
            DependenciesResolver.RegisterServices(services);
            services.AddCors();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey( Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }) ;

            services.AddMvc().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder => generalErrorHandler(builder));
            }

            app.UseRouting();

            app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            }); 
        }

        private static void generalErrorHandler(IApplicationBuilder builder)
        {
            builder.Run(async context =>
            {
                int statusCode;
                string message;
                var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();

                if (exceptionHandler != null && exceptionHandler.Error != null && exceptionHandler.Error is BLLException)
                {
                    statusCode = 400;
                    message = exceptionHandler.Error.Message;
                }
                else
                {
                    statusCode = 500;
                    message = "An error occurred, please try again later...";
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(message);
            });
        }
    }
}
