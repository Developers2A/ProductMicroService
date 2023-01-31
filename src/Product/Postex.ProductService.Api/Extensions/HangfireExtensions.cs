using Hangfire;

namespace Postex.ProductService.Api.Extensions
{
    public static class HangfireExtensions
    {
        public static void UseCustomHangfire(this IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthAdmin(configuration, env) }
            });
        }

        public static IServiceCollection AddHangfireService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfireServer();
            services.AddHangfire(options =>
            {
                options.UseSqlServerStorage(configuration.GetConnectionString("Persistence"));
            });

            return services;
        }
    }
}
