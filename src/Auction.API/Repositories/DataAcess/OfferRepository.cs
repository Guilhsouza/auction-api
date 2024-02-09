using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;

namespace AuctionProject.API.Repositories.DataAcess;

public class OfferRepository : IOfferRepository
{
    private readonly AuctionProjectDbContext _dbContext;

    public OfferRepository(AuctionProjectDbContext dbContext) => _dbContext = dbContext;

    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);

        _dbContext.SaveChanges();

    }
}
