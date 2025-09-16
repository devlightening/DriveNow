using DriveNow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.CarResults
{
    public class GetPublishedCarsQueryResult
    {
      

        public Guid CarId { get; set; }
        public Guid BrandId { get; set; }
        public string Model { get; set; }
        public decimal Kilometer { get; set; }
        public byte Seat { get; set; }
        public int Luggage { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public TransmissionType Transmission { get; set; }
        public CarType CarType { get; set; }
        public FuelType FuelType { get; set; }
        public DriveTypes DriveType { get; set; }
        public int ModelYear { get; set; }
        public bool IsPublished { get; set; }

    }
}
