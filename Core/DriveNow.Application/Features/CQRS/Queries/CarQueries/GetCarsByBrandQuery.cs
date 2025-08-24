using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarsByBrandQuery
    {
        public Guid BrandId { get; set; }

        public GetCarsByBrandQuery(Guid brandId)
        {
            BrandId = brandId;
        }
    }
}
