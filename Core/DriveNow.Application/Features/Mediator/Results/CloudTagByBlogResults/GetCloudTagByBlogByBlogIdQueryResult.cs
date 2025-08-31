using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.CloudTagByBlogResults
{
    public class GetCloudTagByBlogByBlogIdQueryResult
    {
        public string TagName { get; set; }

        public GetCloudTagByBlogByBlogIdQueryResult(string tagName)
        {
            TagName = tagName;
        }
    }
}
