using DriveNow.Application.Features.CQRS.Commands.ContactCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.ContactHadnlers.ContactWriteHandlers
{
    public class UpdateContactCommandHandler(IRepository<Contact> _repository)
    {
        public async Task<Contact> Handle(UpdateContactCommand command)
        {
            var contact = await _repository.GetByIdAsync(command.ContactId);

            if (contact == null)
            {
                return null;
            }

            contact.ContactName = command.ContactName;
            contact.ContactEmail = command.ContactEmail;
            contact.ContactPhone = command.ContactPhone;
            contact.ContactSubject = command.ContactSubject;
            contact.ContactMessage = command.ContactMessage;
            contact.SendDate = command.SendDate;

            return await _repository.UpdateAsync(contact);
        }
    }
}