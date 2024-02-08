using AuctionProject.API.Communication.Requests;
using AuctionProject.API.Entities;
using AuctionProject.API.Repositories;
using AuctionProject.API.Services;

namespace AuctionProject.API.useCases.Offers.CreateOffer;

public class CreateOffer
{
    private readonly LoggedUser _loggedUser;

    public CreateOffer(LoggedUser loggedUser) => _loggedUser = loggedUser; 

    public int Execute(int ItemId, RequestCreateOfferJSON request)
    {
        var repository = new AuctionProjectDbContext();

        var user = _loggedUser.User();

        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = ItemId,
            Price = request.Price,
            UserId = user.Id
        };

        repository.Offers.Add(offer);
        
        repository.SaveChanges();

        return offer.Id;
    }
}
