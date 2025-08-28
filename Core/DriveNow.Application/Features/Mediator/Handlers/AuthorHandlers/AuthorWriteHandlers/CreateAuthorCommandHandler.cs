using DriveNow.Application.Features.Mediator.Commands.AuthorCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.AuthorHandlers.AuthorWriteHandlers
{
    public class CreateAuthorCommandHandler(IRepository<Author> _repository) : IRequestHandler<CreateAuthorCommand, Unit>
    {
        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var values = new Author
            {

                AuthorName = request.AuthorName,
                ImageUrl= request.ImageUrl,
                Description = request.Description
            };

            await _repository.CreateAsync(values);
            return Unit.Value;
        }
    }
}