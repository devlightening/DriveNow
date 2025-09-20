using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.BannerCommands
{
    public class RemoveBannerCommand : IRequest<Unit>
    {
        public Guid BannerId { get; set; }
        public RemoveBannerCommand(Guid bannerId)
        {
            BannerId = bannerId;
        }

    }
}
