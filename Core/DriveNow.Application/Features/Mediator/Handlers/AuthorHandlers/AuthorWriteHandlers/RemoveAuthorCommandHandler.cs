using DriveNow.Application.Features.Mediator.Commands.AuthorCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.AuthorHandlers.AuthorWriteHandlers
{
    public class RemoveAuthorCommandHandler(IRepository<Author> _repository) : IRequestHandler<RemoveAuthorCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.AuthorId);

            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
            return Unit.Value;
        }
    }
}