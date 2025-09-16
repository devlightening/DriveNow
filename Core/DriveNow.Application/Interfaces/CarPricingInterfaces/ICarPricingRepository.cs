using DriveNow.Domain.Entities;

namespace DriveNow.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingWithCars();
        Task<(List<CarPricing> Cars, int Count)> GetPublishedCarPricingWithCarsAndCount();

    }
}
