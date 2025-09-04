using DriveNow.Application.Features.Mediator.Queries.FeatureQueries;
using DriveNow.Application.Features.Mediator.Results.FeatureResults;
using DriveNow.Application.Features.Mediator.Results.FeatureResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FeatureHandlers.FeatureReadHandlers
{

    public class GetFeatureQueryHandler(IRepository<Feature> _repository) : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var features =await _repository.GetAllAsync();
            return features.Select(f => new GetFeatureQueryResult(f.FeatureId, f.FeatureName)).ToList();
        }
    }
}
