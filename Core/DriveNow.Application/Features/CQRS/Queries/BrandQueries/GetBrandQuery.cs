using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandQuery
    {
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string LogoUrl { get; set; }



   

        public GetBrandQuery()
        {
        }

        public GetBrandQuery(Guid brandId, string brandName, string logoUrl)
        {
            BrandId = brandId;
            BrandName = brandName;
            LogoUrl = logoUrl;
        }
    }
}
