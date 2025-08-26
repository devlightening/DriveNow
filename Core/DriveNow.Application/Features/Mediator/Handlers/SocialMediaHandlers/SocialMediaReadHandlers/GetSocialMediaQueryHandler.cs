using DriveNow.Application.Features.Mediator.Queries.SocialMediaQueries;
using DriveNow.Application.Features.Mediator.Results.SocialMediaResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.SocialMediaHandlers.SocialMediaReadHandlers
{
    public class GetSocialMediaQueryHandler(IRepository<SocialMedia> _repository) : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(s => new GetSocialMediaQueryResult(s.SocialMediaId,s.SocialMediaName,s.SocialMediaUrl,s.IconUrl)).ToList();
          
        }
    }
}
