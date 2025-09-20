using DriveNow.Application.Features.Mediator.Queries.BannerQueries;
using DriveNow.Application.Features.Mediator.Results.BannerResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BannerHandlers.BannerReadHandlers
{
    public class GetBannerQueryHandler(IRepository<Banner> _repository) : IRequestHandler<GetBannerQuery, List<GetBannerQueryResult>>
    {
        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
        {
            var Banners = await _repository.GetAllAsync();
            return Banners.Select(f => new GetBannerQueryResult(f.BannerId, f.Title, f.Description, f.VideoDescription,f.VideoUrl)).ToList();
        }
    }
}