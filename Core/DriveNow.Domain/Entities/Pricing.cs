using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Domain.Entities
{
    public class Pricing
    {
        public Guid PricingId { get; set; }
        public string PricingName { get; set; }
        public List<CarPricing> CarPricings { get; set; }

    }
}
