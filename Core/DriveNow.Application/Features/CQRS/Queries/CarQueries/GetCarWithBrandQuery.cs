using System;

namespace DriveNow.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarWithBrandQuery
    {
        public Guid CarId { get; set; }

        public GetCarWithBrandQuery(Guid carId)
        {
            CarId = carId;
        }
    }
}