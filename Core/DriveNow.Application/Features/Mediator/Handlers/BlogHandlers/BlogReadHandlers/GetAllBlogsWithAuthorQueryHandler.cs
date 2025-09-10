using DriveNow.Application.Features.Mediator.Queries.BlogQueries;
using DriveNow.Application.Features.Mediator.Results.BlogResults;
using DriveNow.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogReadHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler(IBlogRepository _repository) : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetAllBlogWithAuthors();
            return blog.Select(b => new GetAllBlogsWithAuthorQueryResult
            {
                BlogId = b.BlogId,
                AuthorId = b.AuthorId,
                Title = b.Title,
                Description = b.Description,
                Slug = b.Slug,
                AuthorName = b.Author.AuthorName,
                CategoryName = b.Category.CategoryName,
                CoverImageUrl = b.CoverImageUrl,
                CreatedDate = b.CreatedDate,
                CategoryId = b.CategoryId
            }).ToList();
        }
    }
}