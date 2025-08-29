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
        [HttpGet("GetCarPricingWithCarList")]
        public async Task<IActionResult> GetCarPricingWithCarList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(values);
        }


    }
}
