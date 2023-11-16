using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Common.Interfaces.Services;
using SneakerCollection.Infrastructure.Authentication;
using SneakerCollection.Infrastructure.Persistence;
using SneakerCollection.Infrastructure.Persistence.Repositories;
using SneakerCollection.Infrastructure.Services;
using System.Text;

namespace SneakerCollection.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           ConfigurationManager configuration)
        {

            services.AddAuth(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISneakerRepository, SneakerRepository>();

            services.AddDbContext<SneakerDbContext>(Options =>
            {
                Options.UseInMemoryDatabase("Sneaker");
            });
            return services;

        }

        public static IServiceCollection AddAuth(this IServiceCollection services,
           ConfigurationManager configuration)
        {
            var jwtsettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName,jwtsettings);
            services.AddSingleton(Options.Create(jwtsettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtsettings.Issuer,
                    ValidAudience = jwtsettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsettings.Secret))
                });
            return services;
        }
    }
}
