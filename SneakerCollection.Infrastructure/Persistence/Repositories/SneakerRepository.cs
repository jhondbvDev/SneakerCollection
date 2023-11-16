using Microsoft.EntityFrameworkCore;
using SneakerCollection.Application.Common.Interfaces.Persistence;
using SneakerCollection.Application.Services.Sneaker;
using SneakerCollection.Domain.Common.Models;
using SneakerCollection.Domain.SneakerAggregate.ValueObjects;
using SneakerCollection.Domain.UserAggregate.Entities;
using SneakerCollection.Domain.UserAggregate.ValueObjects;

namespace SneakerCollection.Infrastructure.Persistence.Repositories;

public class SneakerRepository : ISneakerRepository
{
    private readonly SneakerDbContext _dbContext;

    public SneakerRepository(SneakerDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
     
    public async Task Add(Sneaker sneaker)
    {
        _dbContext.Add(sneaker);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Delete(SneakerId sneakerId)
    {
        var sneaker = _dbContext.Sneakers.SingleOrDefault(x => x.Id.Equals(sneakerId));
        int record = 0;
        if(sneaker != null)
        {
            _dbContext.Remove(sneaker);
            record = await _dbContext.SaveChangesAsync();
        }
        return record > 0;
    }

    public async Task<IEnumerable<Sneaker>>  GetSneakerByUserId(UserId userId)
    {
        var user =  await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.Value==userId.Value);
        if(user == null)
        {
            return Enumerable.Empty<Sneaker>();
        }
        var sneakers = user.Sneakers;
        return sneakers;
    }

    public async Task<Sneaker> GetSneakerById(SneakerId sneakerId,UserId userId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.Value == userId.Value);
        if (user == null)
        {
            return null;
        }
        var sneaker = user.Sneakers.FirstOrDefault(x => x.Id.Equals(sneakerId));
        return sneaker;
    }

    public async Task Update(Sneaker sneaker)
    {
        _dbContext.Sneakers.Update(sneaker);
        await _dbContext.SaveChangesAsync();
        
    }

}

