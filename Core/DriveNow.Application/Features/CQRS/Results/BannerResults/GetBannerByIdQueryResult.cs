using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.BannerResults
{
    public class GetBannerByIdQueryResult
    {
        public Guid BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }

        public GetBannerByIdQueryResult(Guid bannerId, string title, string description, string videoDescription, string videoUrl)
        {
            BannerId = bannerId;
            Title = title;
            Description = description;
            VideoDescription = videoDescription;
            VideoUrl = videoUrl;
        }
    }
}
