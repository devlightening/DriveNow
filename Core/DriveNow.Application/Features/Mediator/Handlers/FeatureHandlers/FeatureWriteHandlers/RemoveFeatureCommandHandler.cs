using DriveNow.Application.Features.Mediator.Commands.FeatureCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FeatureHandlers.FeatureWriteHandlers
{
    internal class RemoveFeatureCommandHandler(IRepository<Feature> _repository) : IRequestHandler<RemoveFeatureCommand>
    {
        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FeatureId);

            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
        }
    }
}