using DriveNow.Domain.Entities;
using DriveNow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.CarResults
{
    public class GetCarWithPricingQueryResult
    {
        public GetCarWithPricingQueryResult(Guid carId, Guid brandId, string model, decimal kilometer,
            byte seat, int luggage, string coverImageUrl, string bigImageUrl,
            int modelYear, TransmissionType transmission, CarType carType,
            FuelType fuelType, DriveTypes driveType, string brandName, string pricingName, decimal pricingAmount)
        {
            CarId = carId;
            BrandId = brandId;
            Model = model;
            Kilometer = kilometer;
            Seat = seat;
            Luggage = luggage;
            CoverImageUrl = coverImageUrl;
            BigImageUrl = bigImageUrl;
            ModelYear = modelYear;
            Transmission = transmission;
            CarType = carType;
            FuelType = fuelType;
            DriveType = driveType;
            BrandName = brandName;
            PricingName = pricingName;
            PricingAmount = pricingAmount;
        }

        public Guid CarId { get; set; }
        public Guid BrandId { get; set; }
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
        public string BrandName { get; set; }
        public string PricingName { get; set; }
        public decimal PricingAmount { get; set; }

    }
}
