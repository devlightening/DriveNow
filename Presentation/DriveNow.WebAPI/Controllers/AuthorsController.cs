using MediatR;
using Microsoft.AspNetCore.Mvc;
using DriveNow.Application.Features.Mediator.Commands.AuthorCommands;
using DriveNow.Application.Features.Mediator.Queries.AuthorQueries;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AuthorList()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "Author successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthor(Guid id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("Author successfully updated.");
        }
    }
}