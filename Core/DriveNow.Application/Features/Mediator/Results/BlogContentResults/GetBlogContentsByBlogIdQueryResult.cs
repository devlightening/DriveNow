

using DriveNow.Domain.Enums;

namespace DriveNow.Application.Features.Mediator.Results.BlogContentResults
{
    public class GetBlogContentsByBlogIdQueryResult
    {
        public GetBlogContentsByBlogIdQueryResult(Guid blogContentId, Guid blogId, string content, BlogContentType contentType, int order)
        {
            BlogContentId = blogContentId;
            BlogId = blogId;
            Content = content;
            ContentType = contentType;
            Order = order;
        }

        public Guid BlogContentId { get; set; }
        public Guid BlogId { get; set; }
        public string Content { get; set; }
        public BlogContentType ContentType { get; set; }
        public int Order { get; set; }
    }
}
