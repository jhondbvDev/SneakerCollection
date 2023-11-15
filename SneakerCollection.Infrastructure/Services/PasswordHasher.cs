using SneakerCollection.Application.Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }

        public bool VerifyPassword(string password , string passwordHash)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(password, passwordHash);
            return verified;
        }
    }
}
