using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.FooterAddessCommands
{
    public class CreateFooterAddressCommand : IRequest
    {
        public string Address { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public CreateFooterAddressCommand(string address, string description, string phoneNumber, string email)
        {
            Address = address;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
        }

    }
}
