
namespace DriveNow.Dtos.BlogDtos
{
    public class ResultBlogDto
    {
        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsPublished { get; set; }

    }
}
