﻿using AuctionProject.API.Entities;
using AuctionProject.API.useCases.Auctions.GetCurrent;
using Microsoft.AspNetCore.Mvc;

namespace AuctionProject.API.Controllers;

public class AuctionController : AuctionBaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAuctionResult([FromServices] GetCurrentAuction useCase)
    {
        var result = useCase.Execute();

        if(result is null)
            return NoContent();

        return Ok(result);
    }
}
