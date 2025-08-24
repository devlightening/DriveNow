using DriveNow.Application.Features.CQRS.Commands.BrandCommands;
using DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController
        (CreateBrandCommandHandler _createBrandCommandHandler,
         UpdateBrandCommandHandler _updateBrandCommandHandler,
         RemoveBrandCommandHandler _removeBrandCommandHandler,
         GetBrandByIdQueryHandler _getBrandByIdQueryHandler,
         GetBrandQueryHandler _getBrandQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var result = await _getBrandQueryHandler.Handle(new GetBrandQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(Guid id)
        {
            var query = new GetBrandByIdQuery(id);
            var result = await _getBrandByIdQueryHandler.Handle(query);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }


            var createdBrand = await _createBrandCommandHandler.Handle(command);
            return CreatedAtAction(
                nameof(GetBrandById),
                new { id = createdBrand.BrandId },
                createdBrand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(Guid id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }


            var updatedBrand = await _updateBrandCommandHandler.Handle(command);


            if (updatedBrand == null)
            {
                return NotFound();
            }


            return Ok(updatedBrand);
        }
    }
}
