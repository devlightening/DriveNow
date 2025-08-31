using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DriveNow.Application.Features.Mediator.Queries.CloudTagByBlogQueries;
using DriveNow.Application.Features.Mediator.Commands.CloudTagByBlogCommands;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudTagByBlogsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CloudTagByBlogList()
        {
            var values = await _mediator.Send(new GetCloudTagByBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCloudTagByBlog(Guid id)
        {
            var value = await _mediator.Send(new GetCloudTagByBlogByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCloudTagByBlog([FromBody] CreateCloudTagByBlogCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "CloudTagByBlog successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCloudTagByBlog(Guid id)
        {
            await _mediator.Send(new RemoveCloudTagByBlogCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCloudTagByBlog([FromBody] UpdateCloudTagByBlogCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("CloudTagByBlog successfully updated.");
        }

        [HttpGet("GetByBlogId/{blogId}")]
        public async Task<IActionResult> GetTagsByBlogId(Guid blogId)
        {
            var values = await _mediator.Send(new GetCloudTagByBlogByBlogIdQuery(blogId));
            if (values == null || !values.Any())
            {
              
                return NotFound();
            }
            return Ok(values);
        }
    }
}