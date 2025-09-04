using DriveNow.Application.Features.Mediator.Results.CommentResults;
using DriveNow.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery:IRequest<GetFeatureByIdQueryResult>
    {
        public Guid FeatureId { get; set; }
        public GetFeatureByIdQuery(Guid featureId)
        {
            FeatureId = featureId;
        }
    }
}
