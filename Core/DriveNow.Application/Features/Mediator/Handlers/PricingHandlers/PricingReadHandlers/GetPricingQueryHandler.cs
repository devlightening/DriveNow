using DriveNow.Application.Features.Mediator.Queries.PricingQueries;
using DriveNow.Application.Features.Mediator.Results.PricingResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.PricingHandlers.PricingReadHandlers
{
    public class GetPricingQueryHandler(IRepository<Pricing> _repository) : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var value =await  _repository.GetAllAsync();
            return  value.Select(s => new GetPricingQueryResult(s.PricingId, s.PricingName)).ToList();
        }
    }
}
