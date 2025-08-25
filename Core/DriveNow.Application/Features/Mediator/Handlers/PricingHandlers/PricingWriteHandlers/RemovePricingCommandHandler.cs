using DriveNow.Application.Features.Mediator.Commands.PricingCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.PricingHandlers.PricingWriteHandlers
{
    public class RemovePricingCommandHandler(IRepository<Pricing> _repository) : IRequestHandler<RemovePricingCommand>
    {
        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingId);
            if (value != null)
            {
               await _repository.RemoveAsync(value);    

            }
            
        }
    }
}
