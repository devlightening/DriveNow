using MediatR;

namespace DriveNow.Application.Features.Mediator.Commands.FeatureCommands
{
    public class CreateFeatureCommand : IRequest<Unit>
    {
        public string FeatureName { get; set; }
        public string IconUrl { get; set; }
   
    }
}
