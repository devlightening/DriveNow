
namespace DriveNow.Domain.Entities
{
    public class CarPricing
    {
        public Guid CarPricingId { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }


        public Guid PricingId { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Price { get; set; }


    }
}
