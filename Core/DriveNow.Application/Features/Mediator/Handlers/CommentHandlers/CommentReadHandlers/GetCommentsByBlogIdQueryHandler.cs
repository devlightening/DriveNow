using DriveNow.Application.Features.Mediator.Queries.CommentQueries;
using DriveNow.Application.Features.Mediator.Results.CommentResults;
using DriveNow.Application.Interfaces.CommentInterfaces; // Note the specific interface
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.CommentHandlers.CommentReadHandlers
{
    public class GetCommentsByBlogIdQueryHandler(ICommentRepository _repository): IRequestHandler<GetCommentsByBlogIdQuery, List<GetCommentsByBlogIdQueryResult>>
    {
        public async Task<List<GetCommentsByBlogIdQueryResult>> Handle(GetCommentsByBlogIdQuery request, CancellationToken cancellationToken)
        {
          
            var comments = await _repository.GetCommentsByBlogId(request.BlogId);

          
            return comments.Select(comment => new GetCommentsByBlogIdQueryResult(
                comment.CommentId,
                comment.Name,
                comment.Content,
                comment.CreatedAt,
                comment.BlogId
            )).ToList();
        }
    }
}