using DriveNow.Application.Features.Mediator.Commands.FeatureCommands;
using DriveNow.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IMediator _mediator) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(Guid id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return StatusCode(201, "Feature successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFeature(Guid id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature([FromBody] UpdateFeatureCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return Ok("Feature successfully updated.");
        }
    }
}