using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.BlogCommands
{
    public sealed class ToggleBlogPublishCommand : IRequest<bool> 
    {
        public ToggleBlogPublishCommand(Guid blogId) => BlogId = blogId;
        public Guid BlogId { get; }
    }
}
