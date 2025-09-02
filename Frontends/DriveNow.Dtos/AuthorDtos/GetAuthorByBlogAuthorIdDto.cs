using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.AuthorDtos
{
    public class GetAuthorByBlogAuthorIdDto
    {
        public Guid BlogId { get; set; }
        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorDescription { get; set; }
        public string AuthorCoverImageUrl { get; set; }
    }
}
