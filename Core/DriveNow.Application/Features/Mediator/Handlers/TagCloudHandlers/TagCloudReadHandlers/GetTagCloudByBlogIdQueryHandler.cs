using DriveNow.Application.Features.Mediator.Queries.TagCloudQueries;
using DriveNow.Application.Features.Mediator.Results.TagCloudResults;
using DriveNow.Application.Interfaces.TagCloudInterfaces;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.TagCloudHandlers.TagCloudReadHandlers
{
    public class GetTagCloudByBlogIdQueryHandler(ITagCloudRepository _repository) : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var tags = await _repository.GetTagCloudsByBlogIdAsync(request.BlogId);

            return tags.Select(t => new GetTagCloudByBlogIdQueryResult(t.TagCloudId,t.TagCloudName,t.BlogId)).ToList();

        }
    }
}
