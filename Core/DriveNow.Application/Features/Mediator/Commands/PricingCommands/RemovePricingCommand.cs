using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.PricingCommands
{
    public class RemovePricingCommand:IRequest
    {
        public Guid PricingId { get; set; }

        public RemovePricingCommand(Guid pricingId)
        {
            PricingId = pricingId;
        }
    }
}
