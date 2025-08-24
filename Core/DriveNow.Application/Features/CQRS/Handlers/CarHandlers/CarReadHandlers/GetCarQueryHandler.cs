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

            return values.Select(x => new GetCarQueryResult(
                x.CarId,
                x.BrandId,
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