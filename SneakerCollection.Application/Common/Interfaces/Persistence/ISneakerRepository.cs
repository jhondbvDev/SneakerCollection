using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.Entities;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Application.Common.Interfaces.Persistence
{
    public  interface ISneakerRepository
    {
        public Task Add(Sneaker sneaker);
        public Task Update(Sneaker sneaker);
        public Task<bool> Delete(SneakerId sneakerId,UserId userId);
        public Task<IEnumerable<Sneaker>> GetSneakerByUserId(UserId userId);
        public Task<Sneaker> GetSneakerById(SneakerId id,UserId userId);

    }
}
