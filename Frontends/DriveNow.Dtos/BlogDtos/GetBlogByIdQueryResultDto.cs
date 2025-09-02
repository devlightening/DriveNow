using DriveNow.Dtos.BlogContentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.BlogDtos
{
    public class GetBlogByIdQueryResultDto
    {
        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; } // ✅ Eklendi
        public string AuthorImageUrl { get; set; } // Opsiyonel, ama faydalı
        public string AuthorDescription { get; set; } // ✅ Eklendi

        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } // ✅ Eklendi

        // Blog içeriği için bir liste eklendi
        public List<ResultBlogContentByBlogIdDto> BlogContents { get; set; } // ✅ Eklendi

        // Etiketler için bir liste eklendi
        public List<string> TagNames { get; set; } // ✅ Eklendi
    }
}
