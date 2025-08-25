using MediatR;
using Microsoft.AspNetCore.Mvc;
using DriveNow.Application.Features.Mediator.Queries.FooterAddressQueries;
using DriveNow.Application.Features.Mediator.Commands.FooterAddessCommands;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(Guid id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress([FromBody] CreateFooterAddressCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return StatusCode(201, "Footer address successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAddress(Guid id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress([FromBody] UpdateFooterAddressCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return Ok("Footer address successfully updated.");
        }
    }
}