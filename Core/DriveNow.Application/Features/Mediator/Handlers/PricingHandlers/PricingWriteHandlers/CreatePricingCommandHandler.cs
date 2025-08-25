using DriveNow.Application.Features.Mediator.Commands.PricingCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.PricingHandlers.PricingWriteHandlers
{
    public class CreatePricingCommandHandler(IRepository<Pricing> _repository) : IRequestHandler<CreatePricingCommand>
    {
        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = new Pricing
            {
                PricingName= request.PricingName
            };
            await _repository.CreateAsync(value);
        }
    }
}
