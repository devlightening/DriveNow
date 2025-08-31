using DriveNow.Application.Features.Mediator.Commands.ParagraphCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.ParagraphHandlers.ParagraphWriteHandlers
{
    public class RemoveParagraphCommandHandler(IRepository<Paragraph> _repository) : IRequestHandler<RemoveParagraphCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveParagraphCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ParagraphId);
            if (value != null)
            {
                await _repository.RemoveAsync(value);

            }
            return Unit.Value;

        }
    }
}
