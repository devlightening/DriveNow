using DriveNow.Domain.Enums;

namespace DriveNow.Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdQueryResult
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
    }
}