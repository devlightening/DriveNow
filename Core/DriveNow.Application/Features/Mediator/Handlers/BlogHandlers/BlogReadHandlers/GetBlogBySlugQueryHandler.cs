using MediatR;
using DriveNow.Application.Interfaces.BlogInterfaces; 
using DriveNow.Application.Features.Mediator.Queries.BlogQueries;
using DriveNow.Application.Features.Mediator.Results.BlogResults;


namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogReadHandlers
{
    public class GetBlogBySlugQueryHandler : IRequestHandler<GetBlogBySlugQuery, GetBlogBySlugQueryResult>
    {
        
        private readonly IBlogRepository _blogRepository;

        public GetBlogBySlugQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

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