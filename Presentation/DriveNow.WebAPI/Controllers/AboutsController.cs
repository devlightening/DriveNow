using DriveNow.Application.Features.CQRS.Commands.AboutCommands;
using DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.AboutHandlers.AboutWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController
        (CreateAboutCommandHandler _createAboutCommandHandler,
        RemoveAboutCommandHandler _removeAboutCommandHandler,
        UpdateAboutCommandHandler _updateAboutCommandHandler,
        GetAboutByIdQueryHandler _getAboutByIdQueryHandler,
        GetAboutQueryHandler _getAboutQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var result = await _getAboutQueryHandler.Handle(new GetAboutQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(Guid id)
        {
            var query = new GetAboutByIdQuery(id);
            var result = await _getAboutByIdQueryHandler.Handle(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }


            var createdAbout = await _createAboutCommandHandler.Handle(command);

            return CreatedAtAction(
                nameof(GetAboutById),
                new { id = createdAbout.AboutId },
                createdAbout);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAbout(Guid id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

  
            var updatedAbout = await _updateAboutCommandHandler.Handle(command);

  
            if (updatedAbout == null)
            {
                return NotFound();
            }

     
            return Ok(updatedAbout);
        }
    }
}