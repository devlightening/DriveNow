using DriveNow.Application.Features.CQRS.Commands.BannerCommands;
using DriveNow.Application.Features.CQRS.Handlers.BannerHandlers.BannerReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.BannerHandlers.BannerWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController
        (CreateBannerCommandHandler _createBannerCommandHandler,
        RemoveBannerCommandHandler _removeBannerCommandHandler,
        UpdateBannerCommandHandler _updateBannerCommandHandler,
        GetBannerByIdQueryHandler _getBannerByIdQueryHandler,
        GetBannerQueryHandler _getBannerQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var result = await _getBannerQueryHandler.Handle(new GetBannerQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBannerById(Guid id)
        {
            var query = new GetBannerByIdQuery(id);
            var result = await _getBannerByIdQueryHandler.Handle(query);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner([FromBody] CreateBannerCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }


            var createdBanner = await _createBannerCommandHandler.Handle(command);
            return CreatedAtAction(
                nameof(GetBannerById),
                new { id = createdBanner.BannerId },
                createdBanner);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBanner(Guid id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBanner(Guid id, [FromBody] UpdateBannerCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }


            var updatedBanner = await _updateBannerCommandHandler.Handle(command);


            if (updatedBanner == null)
            {
                return NotFound();
            }


            return Ok(updatedBanner);
        }

    }
}
