using DriveNow.Application.Features.CQRS.Commands.CarCommands;
using DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(
        CreateCarCommandHandler _createCarCommandHandler,
        UpdateCarCommandHandler _updateCarCommandHandler,
        RemoveCarCommandHandler _removeCarCommandHandler,
        GetCarByIdQueryHandler _getCarByIdQueryHandler,
        GetCarQueryHandler _getCarQueryHandler,
        GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler,
        GetCarsByBrandQueryHandler _getCarsByBrandQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var result = await _getCarQueryHandler.Handle(new GetCarQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            var query = new GetCarByIdQuery(id);
            var result = await _getCarByIdQueryHandler.Handle(query);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdCar = await _createCarCommandHandler.Handle(command);
            return CreatedAtAction(
                nameof(GetCarById),
                new { id = createdCar.CarId },
                createdCar);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(Guid id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            var updatedCar = await _updateCarCommandHandler.Handle(command);

            if (updatedCar == null)
            {
                return NotFound();
            }

            return Ok(updatedCar);
        }

        [HttpGet("GetCarWithBrand/{id}")]
        public async Task<IActionResult> GetCarWithBrand(Guid id)
        {
            var query = new GetCarWithBrandQuery(id);
            var result = await _getCarWithBrandQueryHandler.Handle(query);

            if (result == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }

            return Ok(result);
        }

        [HttpGet("GetCarsByBrand/{brandId}")]
        public async Task<IActionResult> GetCarsByBrand(Guid brandId)
        {
            var query = new GetCarsByBrandQuery(brandId);
            var result = await _getCarsByBrandQueryHandler.Handle(query);

            if (result == null || !result.Any())
            {
                return NotFound($"No cars found for brand ID {brandId}.");
            }

            return Ok(result);
        }
    }
}