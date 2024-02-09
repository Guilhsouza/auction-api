using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;

namespace AuctionProject.API.useCases.Auctions.GetCurrent;

public class GetCurrentAuction
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuction(IAuctionRepository repository) => _repository = repository;

    public Auction? Execute()
    {
        return _repository.GetCurrent();
    }
}