

namespace DriveNow.Dtos.BlogDtos
{
    public class ResultRecentBlogDto
    {
        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string AuthorName { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CommentCount { get; set; }
        
    }
}
