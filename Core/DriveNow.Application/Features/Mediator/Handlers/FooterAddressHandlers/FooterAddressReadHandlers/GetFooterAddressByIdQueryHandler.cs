using DriveNow.Application.Features.Mediator.Queries.FooterAddressQueries;
using DriveNow.Application.Features.Mediator.Results.FooterAddressResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.FooterAddressHandlers.FooterAddressReadHandlers
{
    public class GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> _repository) : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FooterAddressId);
            if (values == null)
            {
                return null;
            }
            return new GetFooterAddressByIdQueryResult
                        (
                            values.FooterAddressId,
                            values.Address,
                            values.Description,
                            values.PhoneNumber,
                            values.Email


                        );
        }
    }
}
