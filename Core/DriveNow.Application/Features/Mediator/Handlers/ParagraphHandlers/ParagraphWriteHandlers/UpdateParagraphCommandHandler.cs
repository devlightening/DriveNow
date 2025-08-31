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
    public class UpdateParagraphCommandHandler(IRepository<Paragraph> _repository) : IRequestHandler<UpdateParagraphCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateParagraphCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ParagraphId);
            if (value == null)
            {
                throw new ArgumentException("Paragraph not found");
            }
            value.LegendDate = request.LegendDate;
            value.LegendName = request.LegendName;
            value.Description = request.Description;
            value.CoverImageUrl = request.CoverImageUrl;
            await _repository.UpdateAsync(value);
            return Unit.Value;

        }
    }
}
