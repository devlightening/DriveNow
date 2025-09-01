using DriveNow.Application.Features.Mediator.Commands.TagCloudCommands;
using DriveNow.Application.Features.Mediator.Queries.CloudTagByBlogQueries;
using DriveNow.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(Guid id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud([FromBody] CreateTagCloudCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return StatusCode(201, "Tag cloud successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTagCloud(Guid id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud([FromBody] UpdateTagCloudCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return Ok("Tag cloud successfully updated.");
        }


        [HttpGet("GetTagCloudsByBlogId/{blogId}")]
        public async Task<IActionResult> GetTagCloudsByBlogId(Guid blogId)
        {
            var values = await _mediator.Send(new GetTagCloudByBlogIdQuery(blogId));
            if (values == null || !values.Any())
            {

                return NotFound();
            }
            return Ok(values);
        }
    }
}