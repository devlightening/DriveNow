using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.FeatureCommands
{
    public class UpdateFeatureCommand : IRequest
    {
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }
        public UpdateFeatureCommand(Guid featureId, string featureName)
        {
            FeatureId = featureId;
            FeatureName = featureName;
        }
    }
}
