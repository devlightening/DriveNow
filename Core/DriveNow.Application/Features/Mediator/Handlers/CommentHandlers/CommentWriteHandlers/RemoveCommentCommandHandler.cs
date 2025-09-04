using DriveNow.Application.Features.Mediator.Commands.CommentCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Comments.Mediator.Handlers.CommentHandlers.CommentWriteHandlers
{
    public class RemoveCommentCommandHandler(IRepository<Comment> _repository) : IRequestHandler<RemoveCommentCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CommentId);

            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
            return Unit.Value;
        }
    }
}