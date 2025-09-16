using DriveNow.Application.Features.DTOs;
using DriveNow.Application.Features.Mediator.Queries.CarPricingQueries;
using DriveNow.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController(IMediator _mediator) : ControllerBase
    {

        [HttpGet("GetPublishedCarPricings")]
        public async Task<IActionResult> GetPublishedCarPricings()
        {
            var query = new GetPublishedCarPricingWithCarQuery();

            var resultDto = await _mediator.Send(query);

            return Ok(resultDto);
        }


    }
}
