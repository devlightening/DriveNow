
namespace DriveNow.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public Guid CommentId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid BlogId { get; set; }
    }
}
