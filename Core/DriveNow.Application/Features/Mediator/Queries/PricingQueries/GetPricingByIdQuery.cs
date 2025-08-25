using DriveNow.Application.Features.Mediator.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public Guid PricingId { get; set; }

        public GetPricingByIdQuery(Guid pricingId)
        {
            PricingId = pricingId;
        }
    }
}
