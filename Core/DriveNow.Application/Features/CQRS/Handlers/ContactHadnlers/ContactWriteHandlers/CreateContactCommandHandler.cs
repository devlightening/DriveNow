using DriveNow.Application.Features.CQRS.Commands.ContactCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.ContactHadnlers.ContactWriteHandlers
{
    public class CreateContactCommandHandler(IRepository<Contact> _repository)
    {
        public async Task<Contact> Handle(CreateContactCommand command)
        {
            var contact = new Contact
            {
                ContactName = command.ContactName,
                ContactEmail = command.ContactEmail,
                ContactPhone = command.ContactPhone,
                ContactMessage = command.ContactMessage,
                ContactSubject = command.ContactSubject,
                SendDate = command.SendDate,

            };
            return await _repository.CreateAsync(contact);
        }
    }
}
