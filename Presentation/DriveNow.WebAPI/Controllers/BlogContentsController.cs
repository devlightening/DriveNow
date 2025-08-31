using DriveNow.Application.Features.Mediator.Commands.BlogContentCommands;
using DriveNow.Application.Features.Mediator.Queries.BlogContentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogContentsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BlogContentList()
        {
            var values = await _mediator.Send(new GetBlogContentQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogContent(Guid id)
        {
            var value = await _mediator.Send(new GetBlogContentByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogContent([FromBody] CreateBlogContentCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "Blog içeriği başarıyla eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBlogContent(Guid id)
        {
            await _mediator.Send(new RemoveBlogContentCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlogContent([FromBody] UpdateBlogContentCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("Blog içeriği başarıyla güncellendi.");
        }

        [HttpGet("GetBlogContentsByBlogId/{blogId}")]
        public async Task<IActionResult> GetBlogContentsByBlogId(Guid blogId)
        {
            var values = await _mediator.Send(new GetBlogContentsByBlogIdQuery(blogId));

            if (values == null || !values.Any())
            {
                return NotFound();
            }

            return Ok(values);
        }
    }
}