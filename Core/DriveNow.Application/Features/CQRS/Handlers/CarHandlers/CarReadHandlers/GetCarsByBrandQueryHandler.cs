using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces;
using DriveNow.Application.Interfaces.CarInterfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetCarsByBrandQueryHandler(ICarRepository _repository)
    {
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {

            var values = await _repository.GetCarsListWithBrands();


            if (values == null)
            {
                return new List<GetCarWithBrandQueryResult>();
            }

           
            return values.Select(car => new GetCarWithBrandQueryResult(
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
                car.DriveType,
                car.ModelYear
            )).ToList();
        }
    }
}