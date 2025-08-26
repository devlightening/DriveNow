using MediatR;

namespace DriveNow.Application.Features.Mediator.Commands.FeatureCommands
{
    public class RemoveFeatureCommand : IRequest<Unit>
    {
        public RemoveFeatureCommand(Guid featureId)
        {
            FeatureId = featureId;
        }

        public Guid FeatureId { get; set; }
    }
}
