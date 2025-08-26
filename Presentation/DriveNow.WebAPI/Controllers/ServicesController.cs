using MediatR;
using Microsoft.AspNetCore.Mvc;
using DriveNow.Application.Features.Mediator.Queries.ServiceQueries;
using DriveNow.Application.Features.Mediator.Commands.ServiceCommands;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(Guid id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "Service successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveService(Guid id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("Service successfully updated.");
        }
    }
}