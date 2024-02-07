using AuctionProject.API.useCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace AuctionProject.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAuctionResult()
    {
        var useCase = new GetCurrentAuction();

        var result = useCase.execute();

        return Ok(result);
    }
}

