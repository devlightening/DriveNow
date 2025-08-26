using DriveNow.Application.Features.Mediator.Queries.SocialMediaQueries;
using DriveNow.Application.Features.Mediator.Results.SocialMediaResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.SocialMediaHandlers.SocialMediaReadHandlers
{
    public class GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> _repository) : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.SocialMediaId);
           if (value == null)
            {
                return null;
            }
            return new GetSocialMediaByIdQueryResult(value.SocialMediaId, value.SocialMediaName, value.SocialMediaUrl, value.IconUrl);

        }
    }
}
