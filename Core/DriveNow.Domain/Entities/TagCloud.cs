

namespace DriveNow.Domain.Entities
{
    public class TagCloud
    {
        public Guid TagCloudId { get; set; }
        public string TagCloudName { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }

    }
}
