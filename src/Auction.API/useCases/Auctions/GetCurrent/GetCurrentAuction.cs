using AuctionProject.API.Entities;
using AuctionProject.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionProject.API.useCases.Auctions.GetCurrent;

public class GetCurrentAuction
{
    public Auction? execute()
    {
        var repository = new AuctionProjectDbContext();

        var today = new DateTime(2024, 01, 25);

        return repository
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}