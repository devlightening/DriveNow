using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class CreateTagCloudCommand : IRequest<Unit>
    {
        public string TagCloudName { get; set; }
        public Guid BlogId { get; set; }
    }
}
