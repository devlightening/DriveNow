using DriveNow.Application.Features.Mediator.Queries.CommentQueries;
using DriveNow.Application.Features.Mediator.Results.CommentResults;
using DriveNow.Application.Interfaces.CommentInterfaces;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.CommentHandlers.CommentReadHandlers
{
    public class GetCommentCountByBlogQueryHandler(ICommentRepository _repository) : IRequestHandler<GetCommentCountByBlogQuery, GetCommentCountByBlogQueryResult>
    {
        public async Task<GetCommentCountByBlogQueryResult> Handle(GetCommentCountByBlogQuery request, CancellationToken cancellationToken)
        {
            var commentCount = await _repository.GetCommentCountByBlog(request.BlogId);
            return new GetCommentCountByBlogQueryResult
            {
                CommentCount = commentCount
            };
        }
    }
}