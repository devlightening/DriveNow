using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand
    {
        public Guid AboutId { get; set; }
        public RemoveAboutCommand(Guid aboutId)
        {
            AboutId = aboutId;
        }
    }
}
