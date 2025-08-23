using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Domain.Entities
{
    public class Testimonial
    {
        public Guid TestimonialId { get; set; }
        public string TestimonialName { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }

    }
}
