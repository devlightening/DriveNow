using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.BlogDtos
{
    public class GetBlogBySlugQueryResultDto
    {
        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }

        public string Title { get; set; }
        public string Slug { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        public string AuthorName { get; set; }
    }
}
