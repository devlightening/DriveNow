using MediatR;
using DriveNow.Application.Interfaces.BlogInterfaces; 
using DriveNow.Application.Features.Mediator.Queries.BlogQueries;
using DriveNow.Application.Features.Mediator.Results.BlogResults;


namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogReadHandlers
{
    public class GetBlogBySlugQueryHandler(IBlogRepository _blogRepository) : IRequestHandler<GetBlogBySlugQuery, GetBlogBySlugQueryResult>
    {      
        public async Task<GetBlogBySlugQueryResult> Handle(GetBlogBySlugQuery request, CancellationToken cancellationToken)
        {
            
            var blog = await _blogRepository.GetBlogBySlugAsync(request.Slug);

            if (blog == null)
            {
                return null;
            }

          
            return new GetBlogBySlugQueryResult
            {
                BlogId = blog.BlogId,
                AuthorId = blog.AuthorId,
                Title = blog.Title,
                Slug = blog.Slug,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                CategoryId = blog.CategoryId,
                AuthorName = blog.Author.AuthorName 
            };
        }
    }
}