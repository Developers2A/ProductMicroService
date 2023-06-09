﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postex.Notification.Application.Behaviours;
using Postex.Notification.Application.Services;
using System.Reflection;

namespace Postex.Notification.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehaviour<,>));
            services.AddScoped<ISmsSender, SmsSender>();
            return services;
        }
    }
}
