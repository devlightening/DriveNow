using DriveNow.Application.Features.Mediator.Commands.ServiceCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.ServiceHandlers.ServiceWriteHandlers
{
    public class RemoveServiceCommandHandler(IRepository<Service> _repository) : IRequestHandler<RemoveServiceCommand,Unit>
    {
        public async Task<Unit> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceId);
            if (value != null)
            {
                await _repository.RemoveAsync(value);   
            }
            return Unit.Value;
            
        }
    }
}
