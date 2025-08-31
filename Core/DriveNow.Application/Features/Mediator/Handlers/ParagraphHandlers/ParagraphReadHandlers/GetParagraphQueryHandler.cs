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
    public class GetParagraphQueryHandler(IRepository<Paragraph> _repository) : IRequestHandler<GetParagraphQuery, List<GetParagraphQueryResult>>
    {
        public async Task<List<GetParagraphQueryResult>> Handle(GetParagraphQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(s => new GetParagraphQueryResult(s.ParagraphId, s.LegendName, s.Description, s.LegendDate,s.CoverImageUrl)).ToList();
        }
    }
}
