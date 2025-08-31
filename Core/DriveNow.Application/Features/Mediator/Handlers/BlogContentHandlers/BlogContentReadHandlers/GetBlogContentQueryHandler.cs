using DriveNow.Application.Features.Mediator.Queries.BlogContentQueries;
using DriveNow.Application.Features.Mediator.Results.BlogContentResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogContentHandlers.BlogContentReadHandlers
{
    public class GetBlogContentQueryHandler(IRepository<BlogContent> _repository) : IRequestHandler<GetBlogContentQuery, List<GetBlogContentQueryResult>>
    {
        public async Task<List<GetBlogContentQueryResult>> Handle(GetBlogContentQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(s => new GetBlogContentQueryResult(s.BlogContentId, s.BlogId, s.Content, s.ContentType, s.Order)).ToList();
        }
    }
}
