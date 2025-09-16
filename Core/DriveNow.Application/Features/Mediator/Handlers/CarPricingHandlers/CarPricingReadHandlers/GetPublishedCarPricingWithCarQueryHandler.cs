using DriveNow.Application.Features.DTOs; // CarListWithCountDto için namespace
using DriveNow.Application.Features.Mediator.Queries.CarPricingQueries;
using DriveNow.Application.Features.Mediator.Results.CarPricingResults;
using DriveNow.Application.Interfaces.CarPricingInterfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.CarPricingHandlers.CarPricingReadHandlers
{
    // Hata giderildi: Handler artık CarListWithCountDto döndürecek şekilde güncellendi.
    public class GetPublishedCarPricingWithCarQueryHandler(ICarPricingRepository _repository)
        : IRequestHandler<GetPublishedCarPricingWithCarQuery, CarListWithCountDto> 
    {
        public async Task<CarListWithCountDto> Handle(GetPublishedCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var (cars, count) = await _repository.GetPublishedCarPricingWithCarsAndCount();

            var mappedCars = cars.Select(f => new GetPublishedCarPricingWithCarQueryResult
            {
                CarPricingId = f.CarPricingId,
                Brand = f.Car.Brand.BrandName,
                Model = f.Car.Model,
                ModelYear = f.Car.ModelYear,
                Price = f.Price,
                CoverImageUrl = f.Car.CoverImageUrl,
                IsPublished = f.Car.IsPublished 
            }).ToList();

 
            return new CarListWithCountDto
            {
                Cars = mappedCars,
                TotalCount = count
            };
        }
    }
}