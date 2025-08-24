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
        CreateContactCommandHandler createContactCommandHandler,
        UpdateContactCommandHandler updateContactCommandHandler,
        RemoveContactCommandHandler removeContactCommandHandler,
        GetContactByIdQueryHandler getContactByIdQueryHandler,
        GetContactQueryHandler getContactQueryHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetContactList()
        {
            var result = await getContactQueryHandler.Handle(new GetContactQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(Guid id)
        {
            var result = await getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            var createdContact = await createContactCommandHandler.Handle(command);
            return CreatedAtAction(
                nameof(GetContactById),
                new { id = createdContact.ContactId },
                createdContact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveContact(Guid id)
        {
            await removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            var updatedContact = await updateContactCommandHandler.Handle(command);

            if (updatedContact == null)
            {
                return NotFound();
            }

            return Ok(updatedContact);
        }
    }
}