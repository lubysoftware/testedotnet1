using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LubyClocker.CrossCuting.IoC.Swagger
{
    public class SwaggerOptionsConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        public SwaggerOptionsConfiguration()
        {
        }

        public void Configure(SwaggerGenOptions options)
        {
            options.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}Controller#{e.ActionDescriptor.RouteValues["action"]}");
            
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Copie 'Bearer ' + token'",
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}

                }
            });
        }
    }

    public static class SwaggerConfig
    {
        public static void AddOpenApiConfiguration(this IServiceCollection services)
        {
            // Add Swagger Generator
            services.AddSwaggerGen(options =>
            {
                options.SchemaFilter<EnumSchemaFilter>();
            });
            
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerOptionsConfiguration>();
        }

    }
}