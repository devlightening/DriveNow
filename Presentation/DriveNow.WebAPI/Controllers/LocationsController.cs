using MediatR;
using Microsoft.AspNetCore.Mvc;
using DriveNow.Application.Features.Mediator.Queries.LocationQueries;
using DriveNow.Application.Features.Mediator.Commands.LocationCommands;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(Guid id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "Location successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveLocation(Guid id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("Location successfully updated.");
        }
    }
}