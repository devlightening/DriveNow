using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.BlogContentCommands
{
    public class RemoveBlogContentCommand : IRequest<Unit>
    {
        public Guid BlogContentId { get; set; }

        public RemoveBlogContentCommand(Guid blogContentId)
        {
            BlogContentId = blogContentId;
        }
    }
}
