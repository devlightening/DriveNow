using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.FooterAddessCommands
{
    public class RemoveFooterAddressCommand : IRequest
    {
        public Guid FooterAddressId { get; set; }
        public RemoveFooterAddressCommand(Guid footerAddressId)
        {
            FooterAddressId = footerAddressId;
        }

    }
}
