using DriveNow.Domain.Entities;
using DriveNow.Domain.Enums;


namespace DriveNow.Dtos.CarDtos
{
    public class ResultCarWithBrandsDto
    {
        public Guid CarId { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public decimal Kilometer { get; set; }
        public byte Seat { get; set; }
        public int Luggage { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public int ModelYear { get; set; }
        public TransmissionType Transmission { get; set; }
        public CarType CarType { get; set; }
        public FuelType FuelType { get; set; }
        public DriveTypes DriveType { get; set; }
    }
}
