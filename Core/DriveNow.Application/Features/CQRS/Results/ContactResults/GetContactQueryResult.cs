using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.ContactResults
{
    public class GetContactQueryResult
    {
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime SendDate { get; set; }
        public GetContactQueryResult(Guid contactId, string contactName, string contactEmail, string contactPhone, string contactSubject, string contactMessage, DateTime sendDate)
        {
            ContactId = contactId;
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            ContactSubject = contactSubject;
            ContactMessage = contactMessage;
            SendDate = sendDate;
        }


    }
}
