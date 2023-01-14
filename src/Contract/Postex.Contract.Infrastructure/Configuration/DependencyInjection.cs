using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postex.Contract.Infrastructure.Data;
using Postex.Contract.Infrastructure.Repositories;
using Postex.SharedKernel.Interfaces;

namespace Postex.Contract.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Contract_db"));
                options.EnableSensitiveDataLogging();
            });

            services.AddRepositories(configuration);
            return services;
        }
        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IWriteRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));
        }
    }
}
