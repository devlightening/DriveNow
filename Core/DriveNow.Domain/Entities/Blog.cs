

namespace DriveNow.Domain.Entities
{
    public class Blog
    {
        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public string Title  { get; set; }
        public string Slug { get; set; }
        public string Description  { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<CloudTagByBlog> CloudTagByBlogs { get; set; }
        public ICollection<BlogContent> BlogContents { get; set; }
        public List<TagCloud> TagClouds { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
