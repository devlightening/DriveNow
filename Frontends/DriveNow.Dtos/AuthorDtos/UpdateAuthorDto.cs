using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.AuthorDtos
{
    public class UpdateAuthorDto
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
