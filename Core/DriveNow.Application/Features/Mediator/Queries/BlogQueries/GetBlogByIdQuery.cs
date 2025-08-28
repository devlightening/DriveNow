using DriveNow.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByIdQuery :IRequest<GetBlogByIdQueryResult>
    {
        public Guid BlogId { get; set; }

        public GetBlogByIdQuery(Guid blogId)
        {
            BlogId = blogId;
        }
    }
}
