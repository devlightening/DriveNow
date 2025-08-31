using DriveNow.Application.Features.Mediator.Results.ParagraphResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.ParagraphQueries
{
    public class GetParagraphByIdQuery:IRequest<GetParagraphByIdQueryResult>
    {
        public Guid ParagraphId { get; set; }

        public GetParagraphByIdQuery(Guid paragraphId)
        {
            ParagraphId = paragraphId;
        }
    }
}
