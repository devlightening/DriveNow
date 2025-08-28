using DriveNow.Application.Features.Mediator.Queries.BlogQueries;
using DriveNow.Application.Features.Mediator.Results.BlogResults;
using DriveNow.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogReadHandlers
{
    internal class GetLast3BlogWithAuthorsQueryHandler(IBlogRepository _repository) : IRequestHandler<GetLast3BlogWithAuthorsQuery, List<GetLast3BlogWithAuthorsQueryResult>>
    {
        public async Task<List<GetLast3BlogWithAuthorsQueryResult>> Handle(GetLast3BlogWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetLast3BlogWithAuthors();
            return blog.Select(blog => new GetLast3BlogWithAuthorsQueryResult
            {
                BlogId = blog.BlogId,
                AuthorId = blog.AuthorId,
                Title = blog.Title,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                CategoryId = blog.CategoryId,
                AuthorName = blog.Author.AuthorName
            }).ToList();
        }
    }
}