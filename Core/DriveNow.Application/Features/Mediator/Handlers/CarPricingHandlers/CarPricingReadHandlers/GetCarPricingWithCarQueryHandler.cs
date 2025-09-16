using DriveNow.Application.Features.Mediator.Queries.CarPricingQueries;
using DriveNow.Application.Features.Mediator.Results.CarPricingResults;
using DriveNow.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.CarPricingHandlers.CarPricingReadHandlers
{
    public class GetCarPricingWithCarQueryHandler(ICarPricingRepository _repository) : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithCars();
            return values.Select(f => new GetCarPricingWithCarQueryResult(f.CarPricingId,f.Car.Brand.BrandName,f.Car.Model,f.Car.ModelYear,f.Price,f.Car.CoverImageUrl)).ToList();
        }
    }
}
