using DriveNow.Application.Features.CQRS.Queries.ContactQueries;
using DriveNow.Application.Features.CQRS.Results.ContactResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.ContactHadnlers.ContactReadHandlers
{
    public class GetContactQueryHandler(IRepository<Contact> _repository)
    {
        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery query)
        {
            var values = await _repository.GetAllAsync();

            
            return values.Select(x => new GetContactQueryResult(
                x.ContactId,
                x.ContactName,
                x.ContactEmail,
                x.ContactPhone,
                x.ContactSubject,
                x.ContactMessage,
                x.SendDate
            )).ToList();
        }
    }
}