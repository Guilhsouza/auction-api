using AuctionProject.API.Communication.Requests;
using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using AuctionProject.API.Services;

namespace AuctionProject.API.useCases.Offers.CreateOffer;

public class CreateOffer
{
    private readonly ILoggedUser _loggedUser;
    private readonly IOfferRepository _repository;

    public CreateOffer(ILoggedUser loggedUser, IOfferRepository repository)
    {
        _loggedUser = loggedUser;
        _repository = repository;
    }

    public int Execute(int ItemId, RequestCreateOfferJSON request)
    {
        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = ItemId,
            Price = request.Price,
            UserId = user.Id
        };

        _repository.Add(offer);

        return offer.Id;
    }
}
