namespace DriveNow.Domain.Entities
{
    public class CloudTagByBlog
    {
        public Guid CloudTagByBlogId { get; set; }
        public string TagName { get; set; }
        public ICollection<BlogCloudTagByBlog> BlogCloudTagByBlogs { get; set; }

    }
}
