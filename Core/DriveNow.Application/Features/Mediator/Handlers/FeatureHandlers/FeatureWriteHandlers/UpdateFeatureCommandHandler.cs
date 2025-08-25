using DriveNow.Application.Features.Mediator.Commands.FeatureCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FeatureHandlers.FeatureWriteHandlers
{
    public class UpdateFeatureCommandHandler(IRepository<Feature> _repository) : IRequestHandler<UpdateFeatureCommand>
    {
        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {

            var feature = await _repository.GetByIdAsync(request.FeatureId);


            if (feature == null)
            {

                throw new Exception($"Feature with ID {request.FeatureId} not found.");
            }


            feature.FeatureName = request.FeatureName;


            await _repository.UpdateAsync(feature);
        }
    }
}