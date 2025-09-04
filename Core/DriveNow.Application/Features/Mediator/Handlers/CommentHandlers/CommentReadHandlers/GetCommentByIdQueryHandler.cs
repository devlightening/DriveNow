using DriveNow.Application.Features.Mediator.Queries.CommentQueries;
using DriveNow.Application.Features.Mediator.Results.CommentResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.CommentHandlers.CommentReadHandlers
{
    public class GetCommentByIdQueryHandler(IRepository<Comment> _repository) : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CommentId);
            if (values == null)
            {
                return null;
            }
            return new GetCommentByIdQueryResult
                        (
                            values.CommentId,
                            values.Name,
                            values.Content,
                            values.CreatedAt,
                            values.BlogId
                        );
        }
    }
}
