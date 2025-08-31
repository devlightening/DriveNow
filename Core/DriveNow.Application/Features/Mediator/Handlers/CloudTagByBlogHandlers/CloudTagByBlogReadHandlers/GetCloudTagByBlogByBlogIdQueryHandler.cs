using DriveNow.Application.Features.Mediator.Queries.CloudTagByBlogQueries;
using DriveNow.Application.Features.Mediator.Results.CloudTagByBlogResults;
using DriveNow.Application.Interfaces.CloudTagByBlogInterfaces;
using MediatR;


namespace DriveNow.Application.Features.Mediator.Handlers.CloudTagByBlogHandlers.CloudTagByBlogReadHandlers
{
    public class GetCloudTagByBlogByBlogIdQueryHandler(ICloudTagByBlogRepository _repository) : IRequestHandler<GetCloudTagByBlogByBlogIdQuery, List<GetCloudTagByBlogByBlogIdQueryResult>>
    {
        public async Task<List<GetCloudTagByBlogByBlogIdQueryResult>> Handle(GetCloudTagByBlogByBlogIdQuery request, CancellationToken cancellationToken)
        { 
            var tags = await _repository.GetTagsByBlogIdAsync(request.BlogId);

            return tags.Select(t => new GetCloudTagByBlogByBlogIdQueryResult(t.TagName)).ToList();
            
        }
    }
}
