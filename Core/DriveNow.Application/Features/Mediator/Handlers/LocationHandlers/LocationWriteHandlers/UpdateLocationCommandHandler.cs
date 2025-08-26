using DriveNow.Application.Features.Mediator.Commands.LocationCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.LocationHandlers.LocationWriteHandlers
{
    public class UpdateLocationCommandHandler(IRepository<Location> _repository) : IRequestHandler<UpdateLocationCommand,Unit>
    {
        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _repository.GetByIdAsync(request.LocationId);
            if (location == null)
            {
                throw new Exception("Location not found");
            }
            location.LocationName = request.LocationName;
            await _repository.UpdateAsync(location);
            return Unit.Value;
        }
    }
}
