using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudCommand :IRequest<Unit>
    {
        public Guid TagCloudId { get; set; }

        public RemoveTagCloudCommand(Guid tagCloudId)
        {
            TagCloudId = tagCloudId;
        }
    }

}
