using Postex.SharedKernel.Extensions;
using Postex.SharedKernel.Settings;
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
            services.Configure<JwtSetting>(Configuration.GetSection("JwtSetting"));
            services.Configure<CodeExpirationSetting>(Configuration.GetSection("CodeExpirationSetting"));
        }

        public void Configure(IApplicationBuilder app)
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
