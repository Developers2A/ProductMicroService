using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postex.SharedKernel.Extensions;
using Postex.UserManagement.Api.Extensions;
using Postex.UserManagement.Application.Configuration;
using Postex.UserManagement.Infrastructure.Configuration;

namespace Postex.UserManagement.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistance(Configuration);
            services.AddCors();
            services.AddControllers();
            services.AddCustomVersioningSwagger();
            services.AddApplicationCore(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomExceptionHandler();
            app.UseCustomSwagger();

            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(config =>
            {
                config.MapControllers();
            });
        }
    }
}
