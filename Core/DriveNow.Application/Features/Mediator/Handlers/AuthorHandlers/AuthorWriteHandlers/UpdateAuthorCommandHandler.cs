using DriveNow.Application.Features.Mediator.Commands.AuthorCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.AuthorHandlers.AuthorWriteHandlers
{
    public class UpdateAuthorCommandHandler(IRepository<Author> _repository) : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {

            var author = await _repository.GetByIdAsync(request.AuthorId);


            if (author == null)
            {

                throw new Exception($"Author with ID {request.AuthorId} not found.");
            }


            author.AuthorName = request.AuthorName;
            author.Description = request.Description;
            author.ImageUrl = request.ImageUrl;



            await _repository.UpdateAsync(author);
            return Unit.Value;
        }
    }
}