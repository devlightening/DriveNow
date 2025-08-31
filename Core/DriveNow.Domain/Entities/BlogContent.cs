using DriveNow.Domain.Enums;
using System;
using System.Net.Mime;

namespace DriveNow.Domain.Entities
{
    public class BlogContent
    {
        public Guid BlogContentId { get; set; }
        public Guid BlogId { get; set; }
        public string Content { get; set; }
        public BlogContentType ContentType { get; set; }
        public int Order { get; set; }
        public Blog Blog { get; set; }
    }
}