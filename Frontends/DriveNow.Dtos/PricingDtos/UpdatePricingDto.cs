using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Dtos.PricingDtos
{
    public class UpdatePricingDto
    {
        public Guid PricingId { get; set; }
        public string PricingName { get; set; }
    }
}
