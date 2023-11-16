using SneakerCollection.Application.Common.Interfaces.Authentication;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Common.Interfaces.Services;
using SneakerCollection.Domain.User;
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
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHasher = passwordHasher;
        }
        public AuthenticationResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User or password is incorrect");
            }

            if(!_passwordHasher.VerifyPassword(password,user.Password)) { 
                throw new Exception("User or password is incorrect");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
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
            var user = User.Create(email, password);
            //var user = new User { Email = email, Password = _passwordHasher.Hash(password) };
            _userRepository.Add(user);
            //create JWT    

            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
               user,
                token
                );
        }
    }
}
