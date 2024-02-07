using AuctionProject.API.Entities;
using AuctionProject.API.useCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace AuctionProject.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAuctionResult()
    {
        var useCase = new GetCurrentAuction();

        var result = useCase.execute();

        if(result is null)
            return NoContent();

        return Ok(result);
    }
}
