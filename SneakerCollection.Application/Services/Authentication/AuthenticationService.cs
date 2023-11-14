using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public AuthenticationResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User or password is incorrect");
            }

            if(user.Password != password) { 
                throw new Exception("User or password is incorrect");

            }

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email, user.Password);

            return new AuthenticationResult(
                user.Id,
                email,
                token
                );
        }

        public AuthenticationResult Register(string email, string password)
        {
            //Check if user exist 
            if(_userRepository.GetUserByEmail(email) != null)
            {
                throw new Exception("User with given email already exists.");
            }
            //create user
            var user = new User { Email = email, Password = password };
            _userRepository.Add(user);
            //create JWT 

            var token = _jwtTokenGenerator.GenerateToken(user.Id, email, password);
            return new AuthenticationResult(
               user.Id,
                email,
                token
                );
        }
    }
}
