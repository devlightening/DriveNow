using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DriveNow.Application.Features.Mediator.Queries.TestimonialQueries;
using DriveNow.Application.Features.Mediator.Commands.TestimonialCommands;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(Guid id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonialCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return StatusCode(201, "Testimonial successfully added.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTestimonial(Guid id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial([FromBody] UpdateTestimonialCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }
            await _mediator.Send(command);
            return Ok("Testimonial successfully updated.");
        }
    }
}