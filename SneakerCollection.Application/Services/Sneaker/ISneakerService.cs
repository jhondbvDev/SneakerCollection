using SneakerCollection.Application.Common.DTOs;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.Entities;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Application.Services.Sneaker
{
    public interface ISneakerService
    {
        Task<SneakerCollectionResponse> GetSneakerByUserId(UserId userId);
        Task AddSneaker(SneakerCollection.Domain.UserAggregate.Entities.Sneaker sneaker);
        Task<bool> RemoveSneaker(SneakerId sneakerId);
        Task UpdateSneaker(SneakerCollection.Domain.UserAggregate.Entities.Sneaker sneaker);

        Task<SneakerCollection.Domain.UserAggregate.Entities.Sneaker> GetSneakerById(SneakerId sneakerId,UserId userId);
    }
}
