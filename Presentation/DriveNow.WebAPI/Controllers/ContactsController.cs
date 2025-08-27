using DriveNow.Application.Features.CQRS.Commands.ContactCommands;
using DriveNow.Application.Features.CQRS.Handlers.ContactHadnlers.ContactReadHandlers;
using DriveNow.Application.Features.CQRS.Handlers.ContactHadnlers.ContactWriteHandlers;
using DriveNow.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(
        GetContactQueryHandler getContactQueryHandler,
        GetContactByIdQueryHandler getContactByIdQueryHandler,
        CreateContactCommandHandler createContactCommandHandler,
        RemoveContactCommandHandler removeContactCommandHandler,
        UpdateContactCommandHandler updateContactCommandHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await getContactQueryHandler.Handle(new GetContactQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(Guid id)
        {
            var value = await getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await createContactCommandHandler.Handle(command);
            return Ok("Contact information added successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(Guid id)
        {
            await removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact information deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await updateContactCommandHandler.Handle(command);
            return Ok("Contact information updated successfully.");
        }
    }
}