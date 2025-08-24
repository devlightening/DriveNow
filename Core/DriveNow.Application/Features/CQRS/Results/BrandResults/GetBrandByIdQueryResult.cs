using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandByIdQueryResult
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public GetBrandByIdQueryResult(Guid brandId, string brandName)
        {
            BrandId = brandId;
            BrandName = brandName;
        }
    }
}
