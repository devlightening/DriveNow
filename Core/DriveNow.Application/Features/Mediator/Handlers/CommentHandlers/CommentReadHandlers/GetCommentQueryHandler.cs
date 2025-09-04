using DriveNow.Application.Features.Mediator.Queries.CommentQueries;
using DriveNow.Application.Features.Mediator.Results.CommentResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;


namespace DriveNow.Application.Features.Mediator.Handlers.CommentHandlers.CommentReadHandlers
{
    public class GetCommentQueryHandler(IRepository<Comment> _repository) : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>
    {
        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(v => new GetCommentQueryResult
            (
                v.CommentId,
                v.Name,
                v.Content,
                v.CreatedAt,
                v.BlogId
            )).ToList();
        }
    }
}