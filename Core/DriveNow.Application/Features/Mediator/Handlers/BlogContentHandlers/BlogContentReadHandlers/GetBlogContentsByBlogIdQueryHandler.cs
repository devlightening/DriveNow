using DriveNow.Application.Features.Mediator.Queries.BlogContentQueries;
using DriveNow.Application.Features.Mediator.Results.BlogContentResults;
using DriveNow.Application.Interfaces.BlogContentInterfaces;
using MediatR;
using System.Linq;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogContentHandlers.BlogContentReadHandlers
{
    public class GetBlogContentsByBlogIdQueryHandler(IBlogContentRepository _repository) : IRequestHandler<GetBlogContentsByBlogIdQuery, List<GetBlogContentsByBlogIdQueryResult>>
    {
        public async Task<List<GetBlogContentsByBlogIdQueryResult>> Handle(GetBlogContentsByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogContentsByBlogIdAsync(request.BlogId);

            return values.Select(x => new GetBlogContentsByBlogIdQueryResult(
                  x.BlogContentId,
                  x.BlogId,
                  x.Content,
                  x.ContentType,
                  x.Order
              )).ToList();
        }
    }
}
