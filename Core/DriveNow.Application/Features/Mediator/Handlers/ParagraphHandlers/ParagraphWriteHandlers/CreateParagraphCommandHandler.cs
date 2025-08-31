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
    public class CreateParagraphCommandHandler(IRepository<Paragraph> _repository) : IRequestHandler<CreateParagraphCommand, Unit>
    {
        public async Task<Unit> Handle(CreateParagraphCommand request, CancellationToken cancellationToken)
        {
            var value = new Paragraph
            {
               LegendDate=request.LegendDate,
               Description= request.Description,
               LegendName= request.LegendName,
               CoverImageUrl= request.CoverImageUrl
            };
            await _repository.CreateAsync(value);
            return Unit.Value;
        }
    }
}