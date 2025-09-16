using DriveNow.Domain.Enums;

namespace DriveNow.Dtos.CarDtos
{
    
    public class CreateCarDto
    {
        public string Model { get; set; }
        public Guid  BrandId { get; set; }
        public int ModelYear { get; set; }
        public int Kilometer { get; set; }
        public int Seat { get; set; }
        public int Luggage { get; set; }
        public TransmissionType Transmission { get; set; } 
        public CarType CarType { get; set; } 
        public FuelType FuelType { get; set; } 
        public DriveTypes DriveType { get; set; }
        public string CoverImageUrl { get; set; } 
        public string BigImageUrl { get; set; }
        public bool IsPublished { get; set; }


    }
}
