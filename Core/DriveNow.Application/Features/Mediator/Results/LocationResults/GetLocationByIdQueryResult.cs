using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.LocationResults
{
    public class GetLocationByIdQueryResult
    {
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public GetLocationByIdQueryResult(Guid locationId, string locationName)
        {
            LocationId = locationId;
            LocationName = locationName;
        }

    }
}
