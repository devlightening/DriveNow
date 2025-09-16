using DriveNow.Application.Features.DTOs;
using DriveNow.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;
namespace DriveNow.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetPublishedCarPricingWithCarQuery : IRequest<CarListWithCountDto>
    {
    }
}
