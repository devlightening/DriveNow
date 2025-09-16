using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetPublishedCarPricingWithCarQueryResult
    {
   

        public Guid CarPricingId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsPublished { get; set; }

    }
}
