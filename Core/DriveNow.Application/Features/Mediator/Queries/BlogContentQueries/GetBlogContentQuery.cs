using DriveNow.Application.Features.Mediator.Results.BlogContentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.BlogContentQueries
{
    public class GetBlogContentQuery : IRequest<List<GetBlogContentQueryResult>>
    {
    }
}
