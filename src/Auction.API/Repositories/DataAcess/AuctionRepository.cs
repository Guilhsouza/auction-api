using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionProject.API.Repositories.NewFolder;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionProjectDbContext _dbContext;
    public AuctionRepository(AuctionProjectDbContext dbContext) => _dbContext = dbContext;  

    public Auction? GetCurrent()
    {
        var today = new DateTime(2024, 01, 25);

        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }

}
