using DriveNow.Application.Features.Mediator.Commands.CommentCommands;
using DriveNow.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _mediator.Send(new GetCommentQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(Guid id)
        {
            var value = await _mediator.Send(new GetCommentByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpGet("GetCommentsByBlog/{id}")]
        public async Task<IActionResult> GetCommentsByBlogId(Guid id)
        {
            var values = await _mediator.Send(new GetCommentsByBlogIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetCommentCountByBlog/{id}")]
        public async Task<IActionResult> GetCommentCountByBlog(Guid id)
        {
            var value = await _mediator.Send(new GetCommentCountByBlogQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "Comment successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(Guid id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("Comment successfully updated.");
        }
    }
}