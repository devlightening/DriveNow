using DriveNow.Application.Features.Mediator.Results.LocationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
    {
        public Guid LocationId { get; set; }
        public GetLocationByIdQuery(Guid locationId)
        {
            LocationId = locationId;
        }
    }
}
