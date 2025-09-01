using DriveNow.Domain.Enums;


namespace DriveNow.Dtos.BlogContentDtos
{
    public class ResultBlogContentByBlogIdDto
    {
        public Guid BlogContentId { get; set; }
        public Guid BlogId { get; set; }
        public string Content { get; set; }
        public BlogContentType ContentType { get; set; }
        public int Order { get; set; }
    }
}
