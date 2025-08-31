using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.CloudTagByBlogResults
{
    public class GetCloudTagByBlogQueryResult
    {
        public GetCloudTagByBlogQueryResult(Guid cloudTagByBlogId, string tagName)
        {
            CloudTagByBlogId = cloudTagByBlogId;
            TagName = tagName;
        }

        public Guid CloudTagByBlogId { get; set; }
        public string TagName { get; set; }

    }
}
