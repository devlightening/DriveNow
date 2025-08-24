using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand
    {
        public Guid ContactId { get; set; }
        public RemoveContactCommand(Guid contactId)
        {
            ContactId = contactId;
        }

    }
}
