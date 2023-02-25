using Hangfire;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Postex.Product.Application.Configuration;
using Postex.Product.Infrastructure.Configuration;
using Postex.Product.ServiceApi.Extensions;
using Postex.Product.ServiceApi.Jobs;
using Postex.SharedKernel.Extensions;

namespace Postex.Product.ServiceApi
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
            services.AddHangfireService(Configuration);
            services.AddSingleton<IHangFireJob, HangFireJob>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
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
            app.UseCustomHangfire(env, Configuration);
            if (!env.IsDevelopment())
            {
                ScheduleHangfireJobs(serviceProvider);
            }

            app.UseEndpoints(config =>
            {
                config.MapControllers();
            });
        }

        private static void ScheduleHangfireJobs(IServiceProvider serviceProvider)
        {
            RecurringJob.AddOrUpdate(
               "Run Everyday 12:00 AM",
               () => serviceProvider.GetService<IHangFireJob>().SyncShops(),
               "0 0 * * *"
               //"*/15 * * * *"
               );

            RecurringJob.AddOrUpdate(
              "Run Everyday 2:00 AM",
              () => serviceProvider.GetService<IHangFireJob>().SyncPrices(),
              //"*/5 * * * *"
              "0 2 * * *"
              );
        }
    }
}
