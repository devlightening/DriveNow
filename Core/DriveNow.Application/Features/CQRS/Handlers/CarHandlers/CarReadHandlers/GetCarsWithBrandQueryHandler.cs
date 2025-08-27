using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces.CarInterfaces;
using DriveNow.Domain.Entities;
using DriveNow.Domain.Enums;
using System.Linq;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetCarsWithBrandQueryHandler(ICarRepository _repository)
    {
        public async  Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarsListWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult(
                x.CarId,
                x.BrandId,
                x.Brand.BrandName,
                x.Model,
                x.Kilometer,
                x.Seat,
                x.Luggage,
                x.CoverImageUrl,
                x.BigImageUrl,
                x.Transmission,
                x.CarType,
                x.FuelType,
                x.DriveType
            )).ToList();
        }
    }
}