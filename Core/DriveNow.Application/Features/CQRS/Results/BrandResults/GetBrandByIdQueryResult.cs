using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandByIdQueryResult
    {
        public GetBrandByIdQueryResult(Guid brandId, string brandName, string logoUrl)
        {
            BrandId = brandId;
            BrandName = brandName;
            LogoUrl = logoUrl;
        }

        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string LogoUrl { get; set; }


    }
}
