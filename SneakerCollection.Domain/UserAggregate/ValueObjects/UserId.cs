using SneakerCollection.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Domain.UserAggregate.ValueObjects
{
    public class UserId : ValueObject
    {
        public Guid Value { get; set; }

        private UserId(Guid value)
        {
            Value = value;
        }

        public static UserId Create(Guid Id)
        {
            return new UserId(Id);
        }

        public static UserId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
