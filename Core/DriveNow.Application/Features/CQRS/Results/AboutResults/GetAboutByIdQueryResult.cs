using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Results.AboutResults
{
    public class GetAboutByIdQueryResult
    {
        public Guid AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public GetAboutByIdQueryResult(Guid aboutId, string title, string description, string imageUrl)
        {
            AboutId = aboutId;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
