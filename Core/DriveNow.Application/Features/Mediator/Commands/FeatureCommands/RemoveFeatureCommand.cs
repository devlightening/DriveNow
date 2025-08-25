using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.FeatureCommands
{
    public class RemoveFeatureCommand : IRequest
    {
        public Guid FeatureId { get; set; }
        public RemoveFeatureCommand(Guid featureId)
        {
            FeatureId = featureId;
        }
    }
}
