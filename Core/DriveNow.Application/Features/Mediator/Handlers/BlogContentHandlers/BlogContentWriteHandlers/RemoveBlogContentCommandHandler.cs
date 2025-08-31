using DriveNow.Application.Features.Mediator.Commands.BlogContentCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogContentHandlers.BlogContentWriteHandlers
{
    public class RemoveBlogContentCommandHandler(IRepository<BlogContent> _repository) : IRequestHandler<RemoveBlogContentCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveBlogContentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogContentId);
            if (value != null)
            {
                await _repository.RemoveAsync(value);

            }
            return Unit.Value;

        }
    }
}
