using DriveNow.Application.Features.Mediator.Queries.FooterAddressQueries;
using DriveNow.Application.Features.Mediator.Results.FooterAddressResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FooterAddressHandlers.FooterAddressReadHandlers
{
    public class GetFooterAddressQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(v => new GetFooterAddressQueryResult
            (
                v.FooterAddressId,
                v.Address,
                v.Description,
                v.PhoneNumber,
                v.Email
            )).ToList();
        }
    }
}
