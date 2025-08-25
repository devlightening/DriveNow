using DriveNow.Application.Features.Mediator.Queries.LocationQueries;
using DriveNow.Application.Features.Mediator.Results.LocationResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.LocationHandlers.LocationReadHandlers
{
    // Arayüzü List<GetLocationQueryResult> olarak değiştirin.
    public class GetLocationQueryHandler(IRepository<Location> _repository) : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
    
        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(l => new GetLocationQueryResult(l.LocationId, l.LocationName)).ToList();
        }
    }
}