using DriveNow.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery :IRequest<GetSocialMediaByIdQueryResult>
    {
        public Guid SocialMediaId { get; set; }

        public GetSocialMediaByIdQuery(Guid socialMediaId)
        {
            SocialMediaId = socialMediaId;
        }
    }
}
