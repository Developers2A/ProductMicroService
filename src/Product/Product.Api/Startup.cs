using Product.Application.Configuration;
using Product.Infrastructure.Configuration;
using ProductService.WebApi.Extensions;
using ProductService.WebApi.Swagger;

namespace ServiceProvider.Api
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
            //services.AddDbContext<ApplicationDBContext>(options =>
            //{
            //    options
            //        .UseSqlServer(configuration["ConnectionStrings:SqlServer"]);
            //});
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
