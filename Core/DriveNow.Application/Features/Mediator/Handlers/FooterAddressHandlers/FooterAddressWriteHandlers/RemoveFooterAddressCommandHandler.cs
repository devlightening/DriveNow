using DriveNow.Application.Features.Mediator.Commands.FooterAddessCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FooterAddressHandlers.FooterAddressWriteHandlers
{
    public class RemoveFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<RemoveFooterAddressCommand,Unit>
    {
        public async Task<Unit> Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.FooterAddressId);

            if (footerAddress != null)
            {

                await _repository.RemoveAsync(footerAddress);
            }
            return Unit.Value;

        }
    }
}