using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.ParagraphCommands
{
    public class RemoveParagraphCommand:IRequest<Unit>
    {
        public RemoveParagraphCommand(Guid paragraphId)
        {
            ParagraphId = paragraphId;
        }

        public Guid ParagraphId { get; set; }
      
    }
}
