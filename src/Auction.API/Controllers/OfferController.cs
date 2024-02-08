using AuctionProject.API.Communication.Requests;
using AuctionProject.API.Filters;
using AuctionProject.API.useCases.Offers.CreateOffer;
using Microsoft.AspNetCore.Mvc;

namespace AuctionProject.API.Controllers;

public class OfferController : AuctionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJSON request,
        [FromServices] CreateOffer useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty, id);
    }
}
