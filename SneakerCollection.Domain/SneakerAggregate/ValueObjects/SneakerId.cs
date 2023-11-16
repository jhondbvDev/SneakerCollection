using SneakerCollection.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Domain.SneakerAggregate.ValueObjects
{
    public class SneakerId : ValueObject
    {
        public Guid Value { get; set; }

        private SneakerId(Guid value)
        {
            Value = value;
        }

        public static SneakerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
