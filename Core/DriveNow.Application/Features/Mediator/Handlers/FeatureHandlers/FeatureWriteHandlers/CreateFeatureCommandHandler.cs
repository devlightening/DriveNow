using DriveNow.Application.Features.Mediator.Commands.FeatureCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FeatureHandlers.FeatureWriteHandlers
{
    public class CreateFeatureCommandHandler(IRepository<Feature> _repository) : IRequestHandler<CreateFeatureCommand>
    {
        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = new Feature
            {
                FeatureName = request.FeatureName
            };

            await _repository.CreateAsync(feature);
        }
    }
}