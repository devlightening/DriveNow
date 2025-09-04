

namespace DriveNow.Domain.Entities
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
