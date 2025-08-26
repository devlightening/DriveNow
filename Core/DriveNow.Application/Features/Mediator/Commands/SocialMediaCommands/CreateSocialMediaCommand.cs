using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand : IRequest<Unit>
    {
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public string IconUrl { get; set; }

    }
}
