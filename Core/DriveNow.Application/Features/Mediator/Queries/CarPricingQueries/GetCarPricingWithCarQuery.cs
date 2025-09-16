using DriveNow.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;


namespace DriveNow.Application.Features.Mediator.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarQuery : IRequest<List<GetCarPricingWithCarQueryResult>>
    {
        public bool IsPublished { get; set; } 

        public GetCarPricingWithCarQuery(bool ısPublished)
        {
            IsPublished = ısPublished;
        }
    }
}
