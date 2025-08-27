using DriveNow.Application.Features.CQRS.Commands.CarCommands;
using DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler) : ControllerBase

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


       
        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            // Parametre göndermeden çağırın
            var value = await _getCarWithBrandQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("GetLast5CarsWithBrands")]
        public async Task<IActionResult> GetLast5CarsWithBrands()
        {
            // Parametre göndermeden çağırın
            var values = await _getLast5CarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}
