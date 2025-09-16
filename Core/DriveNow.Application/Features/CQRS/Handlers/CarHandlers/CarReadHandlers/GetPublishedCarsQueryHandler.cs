using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces.CarInterfaces;
namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetPublishedCarsQueryHandler(ICarRepository _repository)
    {
        public async Task<List<GetPublishedCarsQueryResult>> Handle(GetPublishedCarsQuery query)
        {
           
            var cars = await _repository.GetPublishedCars(query.IsPublished);

            return cars.Select(car => new GetPublishedCarsQueryResult
            {
                CarId = car.CarId,
                BrandId = car.BrandId,
                Model = car.Model,
                Kilometer = car.Kilometer,
                Seat = car.Seat,
                Luggage = car.Luggage,
                CoverImageUrl = car.CoverImageUrl,
                BigImageUrl = car.BigImageUrl,
                Transmission = car.Transmission,
                CarType = car.CarType,
                FuelType = car.FuelType,
                DriveType = car.DriveType,
                ModelYear = car.ModelYear,
                IsPublished = car.IsPublished
            }).ToList();
        }
    }
}