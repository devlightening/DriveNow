using DriveNow.Application.Features.Mediator.Commands.CommentCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Comments.Mediator.Handlers.CommentHandlers.CommentWriteHandlers
{
    public class UpdateCommentCommandHandler(IRepository<Comment> _repository) : IRequestHandler<UpdateCommentCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {

            var values = await _repository.GetByIdAsync(request.CommentId);


            if (values == null)
            {

                throw new Exception($"Comment with ID {request.CommentId} not found.");
            }


            values.Name = request.Name;
            values.Content = request.Content;
            values.CreatedAt = request.CreatedAt;
            values.BlogId = request.BlogId;



            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}