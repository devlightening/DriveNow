using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudByIdQueryResult
    {
        public GetTagCloudByIdQueryResult(Guid tagCloudId, string tagCloudName, Guid blogId)
        {
            TagCloudId = tagCloudId;
            TagCloudName = tagCloudName;
            BlogId = blogId;
        }

        public Guid TagCloudId { get; set; }
        public string TagCloudName { get; set; }
        public Guid BlogId { get; set; }
    }
}
