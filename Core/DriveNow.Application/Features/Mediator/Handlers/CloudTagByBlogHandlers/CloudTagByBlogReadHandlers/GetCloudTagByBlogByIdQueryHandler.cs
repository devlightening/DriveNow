using DriveNow.Application.Features.Mediator.Queries.CloudTagByBlogQueries;
using DriveNow.Application.Features.Mediator.Results.CloudTagByBlogResults;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.CloudTagByBlogHandlers.CloudTagByBlogReadHandlers
{
    public class GetCloudTagByBlogByIdQueryHandler(IRepository<CloudTagByBlog> _repository) : IRequestHandler<GetCloudTagByBlogByIdQuery, GetCloudTagByBlogByIdQueryResult>
    {
        public async Task<GetCloudTagByBlogByIdQueryResult> Handle(GetCloudTagByBlogByIdQuery request, CancellationToken cancellationToken)
        {

            var CloudTagByBlog = await _repository.GetByIdAsync(request.CloudTagByBlogId);


            if (CloudTagByBlog == null)
            {

                return null;
            }


            return new GetCloudTagByBlogByIdQueryResult(CloudTagByBlog.CloudTagByBlogId, CloudTagByBlog.TagName);
        }
    }
}