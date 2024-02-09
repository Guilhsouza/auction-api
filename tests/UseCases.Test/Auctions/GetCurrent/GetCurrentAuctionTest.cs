using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using AuctionProject.API.Enums;
using AuctionProject.API.useCases.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent;

public class GetCurrentAuctionTest
{
    [Fact]
    public void Sucess()
    {
        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1,30))
            .RuleFor(auction => auction.Name, f => f.Lorem.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction) => new List<Item> 
            { 
               new Item
               {
                   Id = f.Random.Number(1,30),
                   Name = f.Commerce.ProductName(),
                   Brand = f.Commerce.Department(),
                   BasePrice = f.Random.Decimal(50,300),
                   Condition = f.PickRandom<Condition>(),
                   AuctionId = auction.Id
               }
            }).Generate();


        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(new AuctionProject.API.Entities.Auction());

        var useCase = new GetCurrentAuction(mock.Object);

        var auction = useCase.Execute();

        auction.Should().NotBeNull();
    }
}
