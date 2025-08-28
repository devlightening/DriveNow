using DriveNow.Application.Features.Mediator.Commands.BlogCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogWriteHandlers
{
    public class RemoveBlogCommandHandler(IRepository<Blog> _repository) : IRequestHandler<RemoveBlogCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);

            if (value != null)
            {
                await _repository.RemoveAsync(value);
            }
            return Unit.Value;
        }
    }
}