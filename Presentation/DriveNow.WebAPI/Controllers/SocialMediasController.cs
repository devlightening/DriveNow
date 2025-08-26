using MediatR;
using Microsoft.AspNetCore.Mvc;
using DriveNow.Application.Features.Mediator.Queries.SocialMediaQueries;
using DriveNow.Application.Features.Mediator.Commands.SocialMediaCommands;

[Route("api/[controller]")]
[ApiController]
public class SocialMediasController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> SocialMediaList()
    {
        var values = await _mediator.Send(new GetSocialMediaQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSocialMedia(Guid id)
    {
        var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
        if (value == null)
        {
            return NotFound();
        }
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid data.");
        }
        await _mediator.Send(command);
        return StatusCode(201, "Social media successfully added.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveSocialMedia(Guid id)
    {
        await _mediator.Send(new RemoveSocialMediaCommand(id));
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid data.");
        }
        await _mediator.Send(command);
        return Ok("Social media successfully updated.");
    }
}