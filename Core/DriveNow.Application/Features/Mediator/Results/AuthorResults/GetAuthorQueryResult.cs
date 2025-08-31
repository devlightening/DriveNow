using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.AuthorResults
{
    public class GetAuthorQueryResult
    {
        public GetAuthorQueryResult(Guid authorId, string authorName, string ımageUrl, string description)
        {
            AuthorId = authorId;
            AuthorName = authorName;
            ImageUrl = ımageUrl;
            Description = description;
        }

        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

    }
}
