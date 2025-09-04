using DriveNow.Application.Features.Mediator.Queries.FeatureQueries;
using DriveNow.Application.Features.Mediator.Results.CommentResults;
using DriveNow.Application.Features.Mediator.Results.FeatureResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FeatureHandlers.FeatureReadHandlers
{
    public class GetFeatureByIdQueryHandler(IRepository<Feature> _repository) : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
   
            var feature = await _repository.GetByIdAsync(request.FeatureId);


            if (feature == null)
            {
    
                return null;
            }

            
            return new GetFeatureByIdQueryResult(feature.FeatureId, feature.FeatureName);
        }
    }
}