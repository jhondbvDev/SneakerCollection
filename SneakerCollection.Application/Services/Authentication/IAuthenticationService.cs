using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SneakerCollection.Application.Common.DTOs;

namespace SneakerCollection.Application.Services.Authentication
{
    public  interface IAuthenticationService
    {
        AuthenticationResult Login(string email, string password);
        AuthenticationResult Register(string email, string password);

    }
}
