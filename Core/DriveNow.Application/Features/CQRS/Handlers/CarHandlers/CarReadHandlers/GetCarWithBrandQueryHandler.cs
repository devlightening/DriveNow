using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces.CarInterfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetCarWithBrandQueryHandler(ICarResository _repository)
    {
        public async Task<GetCarWithBrandQueryResult> Handle(GetCarWithBrandQuery request)
        {
            var car = await _repository.GetCarWithBrandAsync(request.CarId);

            if (car == null)
            {
 
                return null;
            }

  
            return new GetCarWithBrandQueryResult(
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
            );
        }
    }
}