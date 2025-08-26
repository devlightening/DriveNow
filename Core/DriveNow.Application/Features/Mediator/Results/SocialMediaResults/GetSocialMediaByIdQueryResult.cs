namespace DriveNow.Application.Features.Mediator.Results.SocialMediaResults
{
    public class GetSocialMediaByIdQueryResult
    {
        public GetSocialMediaByIdQueryResult(Guid socialMediaId, string socialMediaName, string socialMediaUrl, string ıconUrl)
        {
            SocialMediaId = socialMediaId;
            SocialMediaName = socialMediaName;
            SocialMediaUrl = socialMediaUrl;
            IconUrl = ıconUrl;
        }

        public Guid SocialMediaId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public string IconUrl { get; set; }

    }
}
