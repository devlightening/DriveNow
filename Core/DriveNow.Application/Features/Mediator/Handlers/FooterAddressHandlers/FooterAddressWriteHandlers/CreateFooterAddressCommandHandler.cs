using DriveNow.Application.Features.Mediator.Commands.FooterAddessCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FooterAddressHandlers.FooterAddressWriteHandlers
{
    public class CreateFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<CreateFooterAddressCommand>
    {
        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = new FooterAddress
            {
                Address = request.Address,
                Description = request.Description,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };
             await _repository.CreateAsync(footerAddress);

        }
    }
}
