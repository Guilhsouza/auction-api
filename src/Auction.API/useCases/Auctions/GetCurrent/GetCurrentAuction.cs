using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using AuctionProject.API.Repositories;
using AuctionProject.API.Repositories.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace AuctionProject.API.useCases.Auctions.GetCurrent;

public class GetCurrentAuction
{
    private readonly IAuctionRepository _repository;

    public GetCurrentAuction(IAuctionRepository repository) => _repository = repository;

    public Auction? execute()
    {
        return _repository.GetCurrent();
    }
}