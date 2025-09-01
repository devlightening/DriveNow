using DriveNow.Application.Features.Mediator.Results.TagCloudResults;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery : IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public Guid BlogId { get; set; }
        public GetTagCloudByBlogIdQuery(Guid blogId)
        {
            BlogId = blogId;
        }
    }
}