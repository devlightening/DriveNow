using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandByIdQuery
    {
        public Guid BrandId { get; set; }
        public GetBrandByIdQuery(Guid brandId)
        {
            BrandId = brandId;
        }
    }
}
