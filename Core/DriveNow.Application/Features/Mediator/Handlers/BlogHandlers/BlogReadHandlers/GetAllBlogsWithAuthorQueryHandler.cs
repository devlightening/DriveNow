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
            return blog.Select(b => new GetAllBlogsWithAuthorQueryResult(
                    b.BlogId,
                    b.AuthorId,
                    b.Title,
                    b.Description,
                    b.Author.AuthorName,
                    b.Category.CategoryName,
                    b.CoverImageUrl,
                    b.CreatedDate,
                    b.CategoryId
                )).ToList();
        }
    }
}