using DriveNow.Application.Features.Mediator.Commands.ParagraphCommands;
using DriveNow.Application.Features.Mediator.Queries.ParagraphQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParagraphsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ParagraphList()
        {
            var values = await _mediator.Send(new GetParagraphQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParagraph(Guid id)
        {
            var value = await _mediator.Send(new GetParagraphByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateParagraph([FromBody] CreateParagraphCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return StatusCode(201, "Paragraph successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveParagraph(Guid id)
        {
            await _mediator.Send(new RemoveParagraphCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateParagraph([FromBody] UpdateParagraphCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return Ok("Paragraph successfully updated.");
        }
    }
}