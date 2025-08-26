using DriveNow.Application.Features.Mediator.Commands.ServiceCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.ServiceHandlers.ServiceWriteHandlers
{
  
    public class CreateServiceCommandHandler(IRepository<Service> _repository) : IRequestHandler<CreateServiceCommand, Unit>
    {
        public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var value = new Service
            {
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl
            };
            await _repository.CreateAsync(value);

      
            return Unit.Value;
        }
    }
}