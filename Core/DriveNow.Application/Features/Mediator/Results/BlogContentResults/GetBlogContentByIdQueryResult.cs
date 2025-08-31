using DriveNow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.BlogContentResults
{
    public class GetBlogContentByIdQueryResult
    {
        public GetBlogContentByIdQueryResult(Guid blogContentId, Guid blogId, string content, BlogContentType contentType, int order)
        {
            BlogContentId = blogContentId;
            BlogId = blogId;
            Content = content;
            ContentType = contentType;
            Order = order;
        }

        public Guid BlogContentId { get; set; }
        public Guid BlogId { get; set; }
        public string Content { get; set; }
        public BlogContentType ContentType { get; set; }
        public int Order { get; set; }

    }
}
