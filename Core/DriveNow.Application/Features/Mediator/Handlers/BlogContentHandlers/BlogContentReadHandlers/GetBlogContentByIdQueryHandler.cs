using DriveNow.Application.Features.Mediator.Queries.BlogContentQueries;
using DriveNow.Application.Features.Mediator.Results.BlogContentResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogContentHandlers.BlogContentReadHandlers
{
    public class GetBlogContentByIdQueryHandler(IRepository<BlogContent> _repository) : IRequestHandler<GetBlogContentByIdQuery, GetBlogContentByIdQueryResult>
    {
        public async Task<GetBlogContentByIdQueryResult> Handle(GetBlogContentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogContentId);
            if (value == null)
            {
                return null;
            }
            return new GetBlogContentByIdQueryResult(value.BlogContentId, value.BlogId,value.Content,value.ContentType,value.Order);




        }
    }
}
