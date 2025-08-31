using DriveNow.Application.Features.Mediator.Results.ParagraphResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.ParagraphQueries
{
    public class GetParagraphQuery :IRequest<List<GetParagraphQueryResult>>
    {
    }
}
