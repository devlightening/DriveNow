using DriveNow.Application.Features.Mediator.Commands.ServiceCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.ServiceHandlers.ServiceWriteHandlers
{
    public class UpdateServiceCommandHandler(IRepository<Service> _repository) : IRequestHandler<UpdateServiceCommand,Unit>
    {
        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.ServiceId);
            if (value == null)
            {
                throw new Exception("Service is not Found");
            }
            value.Title = request.Title;
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(value);
            return Unit.Value;
        }
        
    }
}
