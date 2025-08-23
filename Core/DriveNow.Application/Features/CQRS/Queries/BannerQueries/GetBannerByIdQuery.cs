using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerByIdQuery
    {
        public Guid BannerId { get; set; }
        public GetBannerByIdQuery(Guid bannerId)
        {
            BannerId = bannerId;
        }

    }
}
