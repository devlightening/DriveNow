using DriveNow.Application.Features.Mediator.Queries.ServiceQueries;
using DriveNow.Application.Features.Mediator.Results.ServiceResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.ServiceHandlers.ServiceReadHandlers
{
    public class GetServiceByIdQueryHandler(IRepository<Service> _repository) : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ServiceId);
            if (value == null)
            {
                return null;
            }
            return new GetServiceByIdQueryResult(value.ServiceId,value.Title,value.Description,value.IconUrl);
        }
    }
}
