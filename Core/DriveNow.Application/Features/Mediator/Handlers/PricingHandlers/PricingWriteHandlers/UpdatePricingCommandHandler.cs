using DriveNow.Application.Features.Mediator.Commands.PricingCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.PricingHandlers.PricingWriteHandlers
{
    public class UpdatePricingCommandHandler(IRepository<Pricing> _repository) : IRequestHandler<UpdatePricingCommand>
    {
        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingId);
            if(value == null)
            {
                throw new ArgumentException("Pricing not found");
            }
            value.PricingName= request.PricingName;
            await _repository.UpdateAsync(value);
           
        }
    }
}
