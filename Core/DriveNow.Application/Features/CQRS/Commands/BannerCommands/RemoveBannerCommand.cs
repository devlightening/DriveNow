using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand
    {
        public Guid BannerId { get; set; }
        public RemoveBannerCommand(Guid bannerId)
        {
            BannerId = bannerId;
        }

    }
}
