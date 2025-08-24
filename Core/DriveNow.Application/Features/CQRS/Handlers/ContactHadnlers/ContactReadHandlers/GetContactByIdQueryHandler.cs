using DriveNow.Application.Features.CQRS.Queries.ContactQueries;
using DriveNow.Application.Features.CQRS.Results.ContactResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Handlers.ContactHadnlers.ContactReadHandlers
{
    public class GetContactByIdQueryHandler(IRepository<Contact> _repository)
    {
        public async Task<GetContactQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.ContactId);

            if (value == null)
            {
                return null;
            }

            return new GetContactQueryResult(
                value.ContactId,
                value.ContactName,
                value.ContactEmail,
                value.ContactPhone,
                value.ContactSubject,
                value.ContactMessage,
                value.SendDate
            );
        }
    }
}