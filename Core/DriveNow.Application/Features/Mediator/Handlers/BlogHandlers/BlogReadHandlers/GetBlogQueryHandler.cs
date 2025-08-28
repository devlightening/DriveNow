using DriveNow.Application.Features.Mediator.Queries.BlogQueries;
using DriveNow.Application.Features.Mediator.Results.BlogResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogReadHandlers
{
    public class GetBlogQueryHandler(IRepository<Blog> _repository) : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetAllAsync();
            return blog.Select(f => new GetBlogQueryResult(f.BlogId, f.AuthorId, f.Title, f.CoverImageUrl, f.CreatedDate, f.CategoryId)).ToList();
        }
    }
}
