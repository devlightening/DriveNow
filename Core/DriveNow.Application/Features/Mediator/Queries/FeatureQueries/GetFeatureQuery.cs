using DriveNow.Application.Features.Mediator.Results.CommentResults;
using DriveNow.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery :IRequest<List<GetFeatureQueryResult>>
    {

    }
}
