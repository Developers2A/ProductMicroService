﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Infrastructure.Data;
using Postex.UserManagement.Infrastructure.Repositories;

namespace Postex.UserManagement.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Persistence"));
                options.EnableSensitiveDataLogging();
            });

            services.AddRepositories(configuration);
            return services;
        }

        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                // dbContext.Database.Migrate();
            }

            return app;
        }

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IWriteRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));
        }
    }
}
