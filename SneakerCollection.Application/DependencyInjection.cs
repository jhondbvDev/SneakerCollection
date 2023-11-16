using Microsoft.Extensions.DependencyInjection;
using SneakerCollection.Application.Services.Authentication;
using SneakerCollection.Application.Services.Sneaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISneakerService, SneakerService>();
        
            return services;

        }
    }
}
