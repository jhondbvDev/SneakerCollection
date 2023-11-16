using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly SneakerDbContext _dbContext;

        public UserRepository(SneakerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Email == email)!;
        }
        //private static readonly List<User> _users=new();
        //public void Add(User user)
        //{
        //    _users.Add(user);
        //}

        //public User GetUserByEmail(string email)
        //{
        //    return _users.SingleOrDefault(u => u.Email == email);
        //}
    }
}
