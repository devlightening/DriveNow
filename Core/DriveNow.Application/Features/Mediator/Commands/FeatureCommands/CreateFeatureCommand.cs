using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.FeatureCommands
{
    public class CreateFeatureCommand : IRequest
    {
        public string FeatureName { get; set; }
        public CreateFeatureCommand(string featureName)
        {
            FeatureName = featureName;
        }
    }
}
