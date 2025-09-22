using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactSubject { get; set; }

        public string ContactMessage { get; set; }

        public DateTime SendDate { get; set; }
    }
}
