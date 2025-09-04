

namespace DriveNow.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentsByBlogIdQueryResult
    {
        public GetCommentsByBlogIdQueryResult(Guid commentId, string name, string content, DateTime createdAt, Guid blogId)
        {
            CommentId = commentId;
            Name = name;
            Content = content;
            CreatedAt = createdAt;
            BlogId = blogId;
        }

        public Guid CommentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid BlogId { get; set; }
    }
}
