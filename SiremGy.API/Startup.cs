using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SiremGy.Common;
using SiremGy.Exceptions.BLLExceptions;
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
            DependenciesResolver.AddAuthentication(services);
            services.AddCors();
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
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
                    statusCode = exceptionHandler.Error is InvalidEmailOrPasswordException ? 401 : 400;
                    message = exceptionHandler.Error.Message;
                }
                else
                {
                    statusCode = 500;
                    message = "An error occurred, please try again later...";
                }

                context.Response.StatusCode = statusCode;

                context.Response.Headers.Add("Application-Error", message);
                context.Response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                await context.Response.WriteAsync(message);
            });
        }
    }
}
