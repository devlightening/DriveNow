using DriveNow.Application.Features.Mediator.Commands.LocationCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.LocationHandlers.LocationWriteHandlers
{
    public class CreateLocationCommandHandler(IRepository<Location> _repository) : IRequestHandler<CreateLocationCommand>
    {
        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var values = new Location
            {
                LocationName = request.LocationName
            };
            await _repository.CreateAsync(values);
        }
    }
}
