using DriveNow.Application.Features.Mediator.Commands.BannerCommands;
using DriveNow.Application.Features.Mediator.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BannersController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> BannerList()
    {
        var values = await _mediator.Send(new GetBannerQuery());
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBanner(Guid id)
    {
        var value = await _mediator.Send(new GetBannerByIdQuery(id));
        if (value == null)
        {
            return NotFound();
        }
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBanner([FromBody] CreateBannerCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid data.");
        }

        await _mediator.Send(command);
        return StatusCode(201, "Banner successfully added.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBanner(Guid id)
    {
        await _mediator.Send(new RemoveBannerCommand(id));
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBanner([FromBody] UpdateBannerCommand command)
    {
        if (command == null)
        {
            return BadRequest("Invalid data.");
        }

        await _mediator.Send(command);
        return Ok("Banner successfully updated.");
    }
}
