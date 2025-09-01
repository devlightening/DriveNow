// DriveNow.Domain.Entities/BlogCloudTagByBlog.cs

namespace DriveNow.Domain.Entities
{
    public class BlogCloudTagByBlog
    {
        // İlişkinin birincil anahtarlarını (composite key) temsil edecek özellikler
        public Guid BlogId { get; set; }
        public Guid CloudTagByBlogId { get; set; }

        // Navigasyon özellikleri
        public Blog Blog { get; set; }
        public CloudTagByBlog CloudTagByBlog { get; set; }
    }
}