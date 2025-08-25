using DriveNow.Application.Features.Mediator.Queries.LocationQueries;
using DriveNow.Application.Features.Mediator.Results.LocationResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.LocationHandlers.LocationReadHandlers
{
    public class GetLocationByIdQueryHandler(IRepository<Location> _repository) : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.LocationId);


            if (value == null)
            {

                return null;
            }


            return new GetLocationByIdQueryResult(value.LocationId, value.LocationName);

        }
    }
}
