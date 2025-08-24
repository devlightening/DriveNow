using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces;
using DriveNow.Application.Interfaces.CarInterfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetCarsByBrandQueryHandler(ICarResository _repository)
    {
        public async Task<List<GetCarWithBrandQueryResult>> Handle(GetCarsByBrandQuery request)
        {
   
            var cars = await _repository.GetCarsByBrandIdAsync(request.BrandId);

 
            if (cars == null)
            {
                return new List<GetCarWithBrandQueryResult>();
            }

            // Araç listesini DTO listesine dönüştür.
            return cars.Select(car => new GetCarWithBrandQueryResult(
                car.CarId,
                car.BrandId,
                car.Brand?.BrandName,
                car.Model,
                car.Kilometer,
                car.Seat,
                car.Luggage,
                car.CoverImageUrl,
                car.BigImageUrl,
                car.Transmission,
                car.CarType,
                car.FuelType,
                car.DriveType
            )).ToList();
        }
    }
}