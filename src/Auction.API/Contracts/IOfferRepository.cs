using AuctionProject.API.Entities;

namespace AuctionProject.API.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
