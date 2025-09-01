using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class UpdateTagCloudCommand : IRequest<Unit>
    {
        public Guid TagCloudId { get; set; }
        public string TagCloudName { get; set; }
        public Guid BlogId { get; set; }
    }
}
