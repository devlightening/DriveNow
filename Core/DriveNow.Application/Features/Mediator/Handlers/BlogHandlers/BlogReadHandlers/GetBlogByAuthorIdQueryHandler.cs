using DriveNow.Application.Features.Mediator.Queries.BlogQueries;
using DriveNow.Application.Features.Mediator.Results.BlogResults;
using DriveNow.Application.Interfaces.BlogInterfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogReadHandlers
{
    public class GetBlogByAuthorIdQueryHandler(IBlogRepository _repository) : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
         
            var blog = await _repository.GetBlogByAuthorId(request.Id);

          
            if (blog != null)
            {
                var result = new GetBlogByAuthorIdQueryResult
                {
                    BlogId = blog.BlogId,
                    AuthorId = blog.Author.AuthorId,
                    AuthorName = blog.Author.AuthorName,
                    AuthorDescription = blog.Author.Description,
                    AuthorImageUrl = blog.Author.ImageUrl
                };
                return new List<GetBlogByAuthorIdQueryResult> { result };
            }

   
            return new List<GetBlogByAuthorIdQueryResult>();
        }
    }
}