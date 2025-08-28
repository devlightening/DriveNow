using DriveNow.Application.Features.Mediator.Commands.BlogCommands;
using DriveNow.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(Guid id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "Blog successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBlog(Guid id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("Blog successfully updated.");
        }
    }
}
