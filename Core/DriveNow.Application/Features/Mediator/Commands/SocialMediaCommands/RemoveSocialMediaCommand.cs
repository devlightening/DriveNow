using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class RemoveSocialMediaCommand :IRequest<Unit>
    {
        public RemoveSocialMediaCommand(Guid socailMediaId)
        {
            SocialMediaId = socailMediaId;
        }

        public Guid SocialMediaId { get; set; }
    }
}
