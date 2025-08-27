using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Domain.Entities
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; } 
        public string Description { get; set; }

        public List<Blog> Blogs { get; set; }



    }
}
