using DriveNow.Application.Features.Mediator.Results.CommentResults;
using MediatR;


namespace DriveNow.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentsByBlogIdQuery : IRequest<List<GetCommentsByBlogIdQueryResult>>
    {
        public Guid BlogId { get; set; }

        public GetCommentsByBlogIdQuery(Guid blogId)
        {
            BlogId = blogId;
        }
    }
}
