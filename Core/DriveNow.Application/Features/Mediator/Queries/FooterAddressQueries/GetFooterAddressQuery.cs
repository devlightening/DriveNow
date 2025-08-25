using MediatR;
using DriveNow.Application.Features.Mediator.Results.FooterAddressResults;


namespace DriveNow.Application.Features.Mediator.Queries.FooterAddressQueries
{

    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {
        public GetFooterAddressQuery() { }
    }
}