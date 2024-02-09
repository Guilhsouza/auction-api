using AuctionProject.API.Entities;

namespace AuctionProject.API.Contracts;

public interface IAuctionRepository
{
    Auction GetCurrent();
}
