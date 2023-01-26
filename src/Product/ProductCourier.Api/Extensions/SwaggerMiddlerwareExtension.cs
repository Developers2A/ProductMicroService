using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Postex.SharedKernel.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Product.Api.Extensions
{
    public static class SwaggerMiddlerwareExtension
    {
        public static void UseCustomSwagger(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var provider = scope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();

                app.UseSwagger().UseSwaggerUI(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                });
            }
        }

        public static void AddCustomVersioningSwagger(this IServiceCollection services, int majorVersion = 1, int minorVersion = 0)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(majorVersion, minorVersion);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddCustomSwagger();
        }

        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<SwaggerDefaultValues>();
                options.OperationFilter<SwaggerCustomeHeaders>();
                options.DocumentFilter<CustomSwaggerFilter>();
                options.SchemaFilter<AddReadOnlyPropertiesFilter>();
                options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "X-API-Key",
                    Description = "Enter ApiKey",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddFluentValidationRulesToSwagger();
        }
    }
}
