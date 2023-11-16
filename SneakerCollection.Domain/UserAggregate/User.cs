using SneakerCollection.Domain.Common.Models;
using SneakerCollection.Domain.UserAggregate.Entities;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Domain.User
{
    public class User : AggregateRoot<UserId>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        private readonly List<Sneaker> _sneakers = new();

        public IReadOnlyList<Sneaker> sneakers => _sneakers.AsReadOnly();

        private User(UserId userId,
            string? email,
            string? password)
            : base(userId)
        {
            Email = email;
            Password = password;

        }

        public static User Create(
            string? email,
            string? password)
        {
            return new(UserId.CreateUnique(),
                email,
                password);

        }
    }
}
