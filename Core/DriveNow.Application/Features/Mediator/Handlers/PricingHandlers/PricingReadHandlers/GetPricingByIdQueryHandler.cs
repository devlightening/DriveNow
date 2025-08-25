using DriveNow.Application.Features.Mediator.Queries.PricingQueries;
using DriveNow.Application.Features.Mediator.Results.PricingResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.PricingHandlers.PricingReadHandlers
{

    public class GetPricingByIdQueryHandler(IRepository<Pricing> _repository) : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingId);
            if(value == null)
            {
                return null;
            }
            return new GetPricingByIdQueryResult(value.PricingId, value.PricingName);




        }
    }
}
