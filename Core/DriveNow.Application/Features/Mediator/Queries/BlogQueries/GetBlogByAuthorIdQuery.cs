using DriveNow.Application.Features.Mediator.Results.BlogResults;
using MediatR;


namespace DriveNow.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByAuthorIdQuery :IRequest<List<GetBlogByAuthorIdQueryResult>>
    {
        public GetBlogByAuthorIdQuery(Guid ıd)
        {
            Id = ıd;
        }

        public Guid Id { get; set; }
    }
}
