using DriveNow.Application.Features.Mediator.Queries.BlogQueries;
using DriveNow.Application.Features.Mediator.Results.AuthorResults;
using DriveNow.Application.Features.Mediator.Results.BlogResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogReadHandlers
{

    public class GetBlogByIdQueryHandler(IRepository<Blog> _repository) : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.BlogId);


            if (blog == null)
            {

                return null;
            }


            return new GetBlogByIdQueryResult(blog.BlogId, blog.AuthorId, blog.Title, blog.CoverImageUrl,blog.CreatedDate,blog.CategoryId);
        }
    }
}
