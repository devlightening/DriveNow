using DriveNow.Application.Features.Mediator.Results.CloudTagByBlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.CloudTagByBlogQueries
{
    public class GetCloudTagByBlogByIdQuery:IRequest<GetCloudTagByBlogByIdQueryResult>
    {
        public GetCloudTagByBlogByIdQuery(Guid cloudTagByBlogId)
        {
            CloudTagByBlogId = cloudTagByBlogId;
        }

        public Guid CloudTagByBlogId { get; set; }
     
    }
}
