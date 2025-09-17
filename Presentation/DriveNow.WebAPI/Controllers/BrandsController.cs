using DriveNow.Application.Features.CQRS.Commands.BrandCommands;
using DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.BrandHandlers.BrandWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getBrandQueryHandler;

        public BrandsController(
            CreateBrandCommandHandler createBrandCommandHandler,
            UpdateBrandCommandHandler updateBrandCommandHandler,
            RemoveBrandCommandHandler removeBrandCommandHandler,
            GetBrandByIdQueryHandler getBrandByIdQueryHandler,
            GetBrandQueryHandler getBrandQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getBrandQueryHandler = getBrandQueryHandler;
        }

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdBrand = await _createBrandCommandHandler.Handle(command);

                return CreatedAtAction(
                    nameof(GetBrandById),
                    new { id = createdBrand.BrandId }, 
                    createdBrand);
            }
            catch (Exception ex)
            {
             
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while creating the brand.", details = ex.Message });
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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