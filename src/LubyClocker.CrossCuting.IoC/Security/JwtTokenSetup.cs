using System.Text;
using LubyClocker.Domain.Shared.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LubyClocker.CrossCuting.IoC.Security
{
    public static class JwtTokenSetup
    {
        public static void AddJwtTokenSetup(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfig = new TokenConfigs
            {
                Issuer = configuration.GetValue("JWT_ISSUER", "Luby.Clocker.Api"),
                Seconds = configuration.GetValue("JWT_SECONDS", 43200),
                Secret = configuration.GetValue("JWT_SECRET", "c86edf30-53e6-45e9-82c3-0007aa53c3cf"),
                Audience = configuration.GetValue("JWT_AUDIENCE", "http://localhost")
            };

            services.AddSingleton<TokenConfigs>(tokenConfig);
 
            // HttpContextAccessor
            services.AddHttpContextAccessor();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfig.Secret)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = tokenConfig.Audience,
                    ValidIssuer = tokenConfig.Issuer
                };
            });
        }
    }
}