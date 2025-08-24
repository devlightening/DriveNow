using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandQueryResult
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }

        public GetBrandQueryResult(Guid brandId, string brandName)
        {
            BrandId = brandId;
            BrandName = brandName;
        }
    }
}