using DriveNow.Application.Features.Mediator.Results.CommentResults;
using MediatR;


namespace DriveNow.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentCountByBlogQuery:IRequest<GetCommentCountByBlogQueryResult>
    {
        public GetCommentCountByBlogQuery(Guid blogId)
        {
            BlogId = blogId;
        }
        public Guid BlogId { get; set; }
    }
}
