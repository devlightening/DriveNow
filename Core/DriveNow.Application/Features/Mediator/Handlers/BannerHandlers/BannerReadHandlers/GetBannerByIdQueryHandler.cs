using DriveNow.Application.Features.Mediator.Queries.BannerQueries;
using DriveNow.Application.Features.Mediator.Queries.BannerQueries;
using DriveNow.Application.Features.Mediator.Results.BannerResults;
using DriveNow.Application.Features.Mediator.Results.BannerResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.BannerHandlers.BannerReadHandlers
{
    public class GetBannerByIdQueryHandler(IRepository<Banner> _repository) : IRequestHandler<GetBannerByIdQuery, GetBannerByIdQueryResult>
    {
        public async  Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var Banner = await _repository.GetByIdAsync(request.BannerId);


            if (Banner == null)
            {

                return null;
            }


            return new GetBannerByIdQueryResult(Banner.BannerId, Banner.Title, Banner.Description, Banner.VideoDescription, Banner.VideoUrl);
        }
    }
}