

using DriveNow.Application.Features.Mediator.Results.BlogContentResults;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Queries.BlogContentQueries
{
    public class GetBlogContentsByBlogIdQuery : IRequest<List<GetBlogContentsByBlogIdQueryResult>>
    {
        public GetBlogContentsByBlogIdQuery(Guid blogId)
        {
            BlogId = blogId;
        }

        public Guid BlogId { get; set; }
    }
}