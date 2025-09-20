using DriveNow.Application.Features.Mediator.Results.BannerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetBannerByIdQuery : IRequest<GetBannerByIdQueryResult>
    {
        public Guid BannerId { get; set; }
        public GetBannerByIdQuery(Guid bannerId)
        {
            BannerId = bannerId;
        }

    }
}
