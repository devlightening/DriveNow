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
    public class GetTagCloudByIdQueryHandler(IRepository<TagCloud> _repository) : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                return null;
            }
            return new GetTagCloudByIdQueryResult(value.TagCloudId,value.TagCloudName, value.BlogId);
        }
    }
}
