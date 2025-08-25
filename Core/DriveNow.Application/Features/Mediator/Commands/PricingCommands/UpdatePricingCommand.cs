using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.PricingCommands
{
    public class UpdatePricingCommand : IRequest
    {
        public UpdatePricingCommand(Guid pricingId, string pricingName)
        {
            PricingId = pricingId;
            PricingName = pricingName;
        }

        public Guid PricingId { get; set; }
        public string PricingName { get; set; }


    }
}
