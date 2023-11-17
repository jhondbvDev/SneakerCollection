using SneakerCollection.Application.Common.DTOs;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace SneakerCollection.Application.Services.Sneaker
{
    public class SneakerService : ISneakerService
    {
        private readonly ISneakerRepository _sneakerRepository;

        public SneakerService(ISneakerRepository sneakerRepository)
        {
            _sneakerRepository = sneakerRepository;    
                
        }
        public async Task AddSneaker(Domain.UserAggregate.Entities.Sneaker sneaker)
        {
            await _sneakerRepository.Add(sneaker);
        }

        public async Task<Domain.UserAggregate.Entities.Sneaker>  GetSneakerById(SneakerId sneakerId,UserId userId)
        {
            
            var sneaker = await _sneakerRepository.GetSneakerById(sneakerId,userId);
  

            return sneaker;
        }

        public async Task<SneakerCollectionResponse> GetSneakerByUserId(UserId userId)
        {
            var dbsneakers =  _sneakerRepository.GetSneakerByUserId(userId).Result.ToList();
            SneakerCollectionResponse response = new SneakerCollectionResponse() {
                sneakers = dbsneakers.Select(s=>new SneakerResponse()
                {
                    Id=s.Id.Value.ToString(),
                    Brand=s.Brand,
                    Name=s.Name,
                    Price=s.Price,
                    Rate=s.Rate,
                    Size=s.Size,
                    Year=s.Year,
                    UserId = s.UserId.Value.ToString()
                }).ToList()
                };
            return response;
        }

        public async Task<bool> RemoveSneaker(SneakerId sneakerId,UserId userId)
        {
           return await _sneakerRepository.Delete(sneakerId,userId);
        }

        public async Task UpdateSneaker(Domain.UserAggregate.Entities.Sneaker sneaker)
        {
           await  _sneakerRepository.Update(sneaker);
        }
    }
}
