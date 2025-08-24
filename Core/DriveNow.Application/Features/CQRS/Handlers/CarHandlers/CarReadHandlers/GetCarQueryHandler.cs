using DriveNow.Application.Features.CQRS.Queries.CarQueries;
using DriveNow.Application.Features.CQRS.Results.CarResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.CarHandlers.CarReadHandlers
{
    public class GetCarQueryHandler(IRepository<Car> _repository)
    {
        public async Task<List<GetCarQueryResult>> Handle(GetCarQuery query)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetCarQueryResult
            {
                CarId = x.CarId,
                BrandId = x.BrandId,
                Model = x.Model,
                Kilometer = x.Kilometer,
                Seat = x.Seat,
                Luggage = x.Luggage,
                CoverImageUrl = x.CoverImageUrl,
                BigImageUrl = x.BigImageUrl,
                Transmission = x.Transmission,
                CarType = x.CarType,
                FuelType = x.FuelType,
                DriveType = x.DriveType
            }).ToList();
        }
    }
}