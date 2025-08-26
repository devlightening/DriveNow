using DriveNow.Application.Features.Mediator.Commands.LocationCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.LocationHandlers.LocationWriteHandlers
{
    public class RemoveLocationCommandHandler(IRepository<Location> _repository) : IRequestHandler<RemoveLocationCommand,Unit>
    {
        public async Task<Unit> Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.LocationId);
            if(values != null)
            {
               await _repository.RemoveAsync(values);
            }
            return Unit.Value;
        }
    }
}
