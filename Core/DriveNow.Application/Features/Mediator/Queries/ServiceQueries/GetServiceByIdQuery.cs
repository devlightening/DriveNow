using DriveNow.Application.Features.Mediator.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.ServiceQueries
{
    public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
    {
        public Guid ServiceId { get; set; }

        public GetServiceByIdQuery(Guid serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
