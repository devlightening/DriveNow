using DriveNow.Application.Features.CQRS.Queries.BannerQueries;
using DriveNow.Application.Features.CQRS.Results.BannerResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;

namespace DriveNow.Application.Features.CQRS.Handlers.BannerHandlers.BannerReadHandlers
{
    public class GetBannerByIdQueryHandler (IRepository<Banner> _repository)
    {
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.BannerId);


            if (value == null)
            {

                return null;
            }

            return new GetBannerByIdQueryResult
            {
                BannerId = value.BannerId,
                Title = value.Title,
                Description = value.Description,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl

            };
        }
    }
}
