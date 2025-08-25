using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.PricingCommands
{
    public class CreatePricingCommand : IRequest
    {
        public CreatePricingCommand( string pricingName)
        {
            PricingName = pricingName;
        }
        public string PricingName { get; set; }


    }
}
