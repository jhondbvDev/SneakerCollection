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

        public IReadOnlyList<Sneaker> Sneakers => _sneakers.ToList();

#pragma warning disable CS8618
        protected User() { }
#pragma warning restore CS8618

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
