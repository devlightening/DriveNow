using DriveNow.Domain.Enums;
using System;

namespace DriveNow.Application.Features.CQRS.Commands.CarCommands
{
    public class CreateCarCommand
    {
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

        public CreateCarCommand(Guid brandId, string model, decimal kilometer, byte seat, int luggage, string coverImageUrl, string bigImageUrl, TransmissionType transmission, CarType carType, FuelType fuelType, DriveTypes driveType,int modelYear)
        {
            BrandId = brandId;
            Model = model;
            Kilometer = kilometer;
            Seat = seat;
            Luggage = luggage;
            CoverImageUrl = coverImageUrl;
            BigImageUrl = bigImageUrl;
            Transmission = transmission;
            CarType = carType;
            FuelType = fuelType;
            DriveType = driveType;
            ModelYear = modelYear;
        }
    }
}