using DriveNow.Application.Features.CQRS.Queries.BannerQueries;
using DriveNow.Application.Features.CQRS.Results.BannerResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.BannerHandlers.BannerReadHandlers
{
    public class GetBannerQueryHandler(IRepository<Banner> _repository)
    {
        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery query)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                Title = x.Title,
                Description = x.Description,
                VideoDescription = x.VideoDescription,
                VideoUrl = x.VideoUrl
            }).ToList();
        }
    }
}