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
    public class RemoveContactCommandHandler(IRepository<Contact> _repository)
    {
        public async Task Handle(RemoveContactCommand command)
        {
            var contact = await _repository.GetByIdAsync(command.ContactId);
            if (contact != null)
            {
                await _repository.RemoveAsync(contact);
            }
        }
    }
}
