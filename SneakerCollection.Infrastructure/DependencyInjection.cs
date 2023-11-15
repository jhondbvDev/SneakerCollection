using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Common.Interfaces.Services;
using SneakerCollection.Application.Services.Authentication;
using SneakerCollection.Infrastructure.Authentication;
using SneakerCollection.Infrastructure.Persistence;
using SneakerCollection.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Infrastructure
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
           ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;

        }
    }
}
