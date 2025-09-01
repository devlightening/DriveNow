using DriveNow.Application.Features.Mediator.Queries.TagCloudQueries;
using DriveNow.Application.Features.Mediator.Results.TagCloudResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.TagCloudHandlers.TagCloudReadHandlers
{
    public class GetTagCloudQueryHandler(IRepository<TagCloud> _repository) : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(s => new GetTagCloudQueryResult(s.TagCloudId, s.TagCloudName ,s.BlogId)).ToList();
        }
    }
}
