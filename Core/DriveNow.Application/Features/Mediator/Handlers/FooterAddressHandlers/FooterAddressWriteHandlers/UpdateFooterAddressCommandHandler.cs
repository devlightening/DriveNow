using DriveNow.Application.Features.Mediator.Commands.FooterAddessCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.FooterAddressHandlers.FooterAddressWriteHandlers
{
    public class UpdateFooterAddressCommandHandler(IRepository<FooterAddress> _repository) : IRequestHandler<UpdateFooterAddressCommand>
    {
        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
           
            var footerAddress = await _repository.GetByIdAsync(request.FooterAddressId);

            if (footerAddress != null)
            {
      
                footerAddress.Address = request.Address;
                footerAddress.Description = request.Description;
                footerAddress.PhoneNumber = request.PhoneNumber;
                footerAddress.Email = request.Email;

                await _repository.UpdateAsync(footerAddress);
            }
        }
    }
}