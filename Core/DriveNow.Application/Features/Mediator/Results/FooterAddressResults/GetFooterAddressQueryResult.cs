using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.FooterAddressResults
{
    public class GetFooterAddressQueryResult
    {
        public Guid FooterAddressId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public GetFooterAddressQueryResult(Guid footerAddressId, string address, string description, string phoneNumber, string email)
        {
            FooterAddressId = footerAddressId;
            Address = address;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
        }

    }
}
