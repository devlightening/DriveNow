using DriveNow.Application.Features.Mediator.Results.BlogResults;
using MediatR;


namespace DriveNow.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogBySlugQuery : IRequest<GetBlogBySlugQueryResult>
    {
        public string Slug { get; set; }

        public GetBlogBySlugQuery(string slug)
        {
            Slug = slug;
        }
    }
}
