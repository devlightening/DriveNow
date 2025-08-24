using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuery
    {
        public Guid ContactId { get; set; }
        public GetContactByIdQuery(Guid contactId)
        {
            ContactId = contactId;
        }
    }
}
