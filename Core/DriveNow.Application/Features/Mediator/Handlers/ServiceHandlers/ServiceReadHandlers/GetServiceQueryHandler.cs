using DriveNow.Application.Features.Mediator.Queries.ServiceQueries;
using DriveNow.Application.Features.Mediator.Results.ServiceResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.ServiceHandlers.ServiceReadHandlers
{
    public class GetServiceQueryHandler(IRepository<Service> _repository) : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(s => new GetServiceQueryResult(s.ServiceId, s.Title, s.Description, s.IconUrl)).ToList();
        }
    }
}
