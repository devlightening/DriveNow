using MediatR;
using Microsoft.AspNetCore.Mvc;
using DriveNow.Application.Features.Mediator.Queries.PricingQueries;
using DriveNow.Application.Features.Mediator.Commands.PricingCommands;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(Guid id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing([FromBody] CreatePricingCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "Pricing successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePricing(Guid id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing([FromBody] UpdatePricingCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("Pricing successfully updated.");
        }
    }
}