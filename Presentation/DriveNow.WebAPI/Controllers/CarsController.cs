using DriveNow.Application.Features.CQRS.Commands.CarCommands;
using DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using MediatR;
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
        GetLast5CarsWithBrandQueryHandler _getLast5CarsWithBrandQueryHandler,
        GetPublishedCarsQueryHandler _getPublishedCarsQueryHandler,IMediator _mediator) : ControllerBase

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
            
            var value = await _getCarWithBrandQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("GetLast5CarsWithBrands")]
        public async Task<IActionResult> GetLast5CarsWithBrands()
        {
         
            var values = await _getLast5CarsWithBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("GetAvailableCars")]
        public async Task<IActionResult> GetAvailableCars()
        {
            var query = new GetPublishedCarsQuery(true);
            var availableCars = await _getPublishedCarsQueryHandler.Handle(query);
            return Ok(availableCars);
        }
        [HttpPatch("UpdatePublicationStatus")]
        public async Task<IActionResult> UpdatePublicationStatus([FromBody] UpdateCarPublicationStatusCommand command)
        {
            if (command == null || command.CarId == Guid.Empty)
            {
                return BadRequest("Invalid request data.");
            }

            try
            {
                var result = await _mediator.Send(command);
                if (result.Success)
                {
                    return Ok(new { success = true, message = "Car availability status updated successfully." });
                }
                else
                {
                    return Ok(new { success = false, message = result.Message ?? "Failed to update car status." });
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { success = false, message = "An internal server error occurred." });
            }
        }
    }
}
