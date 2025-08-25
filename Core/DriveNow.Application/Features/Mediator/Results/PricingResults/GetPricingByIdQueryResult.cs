using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.PricingResults
{
    public class GetPricingByIdQueryResult
    {
        public GetPricingByIdQueryResult(Guid pricingId, string pricingName)
        {
            PricingId = pricingId;
            PricingName = pricingName;
        }

        public Guid PricingId { get; set; }
        public string PricingName { get; set; }


    }
}
