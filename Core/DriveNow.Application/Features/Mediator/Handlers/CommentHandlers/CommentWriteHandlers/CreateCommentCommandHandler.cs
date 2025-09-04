using DriveNow.Application.Features.Mediator.Commands.CommentCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Comments.Mediator.Handlers.CommentHandlers.CommentWriteHandlers
{
    public class CreateCommentCommandHandler(IRepository<Comment> _repository) : IRequestHandler<CreateCommentCommand, Unit>
    {
        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var values = new Comment
            {
               Name = request.Name,
               Content = request.Content,
               CreatedAt = request.CreatedAt,
               BlogId = request.BlogId
            };

            await _repository.CreateAsync(values);
            return Unit.Value;
        }
    }
}