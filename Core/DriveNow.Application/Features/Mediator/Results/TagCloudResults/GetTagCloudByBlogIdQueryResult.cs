

namespace DriveNow.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudByBlogIdQueryResult
    {
        public GetTagCloudByBlogIdQueryResult(Guid tagCloudId, string tagCloudName, Guid blogId)
        {
            TagCloudId = tagCloudId;
            TagCloudName = tagCloudName;
            BlogId = blogId;
        }

        public Guid TagCloudId { get; set; }
        public string TagCloudName { get; set; }
        public Guid BlogId { get; set; }


    }
}
