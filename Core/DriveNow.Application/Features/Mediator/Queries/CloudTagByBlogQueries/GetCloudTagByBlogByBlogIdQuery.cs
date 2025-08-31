using DriveNow.Application.Features.Mediator.Results.CloudTagByBlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.CloudTagByBlogQueries
{
    public class GetCloudTagByBlogByBlogIdQuery: IRequest<List<GetCloudTagByBlogByBlogIdQueryResult>>
    {
        public Guid BlogId { get; set; }
        public GetCloudTagByBlogByBlogIdQuery(Guid blogId)
        {
            BlogId = blogId;
        }
    }
}
