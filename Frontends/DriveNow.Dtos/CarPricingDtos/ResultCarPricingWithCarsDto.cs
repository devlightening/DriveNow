using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.CarPricingDtos
{
    public class ResultCarPricingWithCarsDto
    {
        public Guid CarPricingId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; }

    }
}
