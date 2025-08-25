using DriveNow.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery : IRequest<GetFooterAddressByIdQueryResult>
    {
        public Guid FooterAddressId { get; set; }
        public GetFooterAddressByIdQuery(Guid footerAddressId)
        {
            FooterAddressId = footerAddressId;
        }


    }
}
