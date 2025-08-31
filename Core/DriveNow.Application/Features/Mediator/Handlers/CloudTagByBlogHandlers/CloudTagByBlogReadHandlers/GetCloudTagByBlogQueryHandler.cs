using DriveNow.Application.Features.Mediator.Queries.CloudTagByBlogQueries;
using DriveNow.Application.Features.Mediator.Results.CloudTagByBlogResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.CloudTagByBlogHandlers.CloudTagByBlogReadHandlers
{
    public class GetCloudTagByBlogQueryHandler(IRepository<CloudTagByBlog> _repository) : IRequestHandler<GetCloudTagByBlogQuery, List<GetCloudTagByBlogQueryResult>>
    {
        public async Task<List<GetCloudTagByBlogQueryResult>> Handle(GetCloudTagByBlogQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(s => new GetCloudTagByBlogQueryResult(s.CloudTagByBlogId, s.TagName)).ToList();
        }
    }
}
