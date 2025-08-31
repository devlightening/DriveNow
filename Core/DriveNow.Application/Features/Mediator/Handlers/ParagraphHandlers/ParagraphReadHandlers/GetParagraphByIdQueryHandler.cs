using DriveNow.Application.Features.Mediator.Queries.ParagraphQueries;
using DriveNow.Application.Features.Mediator.Results.ParagraphResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.ParagraphHandlers.ParagraphReadHandlers
{
    public class GetParagraphByIdQueryHandler(IRepository<Paragraph> _repository) : IRequestHandler<GetParagraphByIdQuery, GetParagraphByIdQueryResult>
    {
        public async Task<GetParagraphByIdQueryResult> Handle(GetParagraphByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ParagraphId);
            if (value == null)
            {
                return null;
            }
            return new GetParagraphByIdQueryResult(value.ParagraphId,value.LegendName, value.Description,value.LegendDate,value.CoverImageUrl);




        }
    }
}