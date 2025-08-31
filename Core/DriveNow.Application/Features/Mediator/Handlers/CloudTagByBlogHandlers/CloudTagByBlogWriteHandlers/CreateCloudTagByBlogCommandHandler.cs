using DriveNow.Application.Features.Mediator.Commands.CloudTagByBlogCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.CloudTagByBlogHandlers.CloudTagByBlogWriteHandlers
{
    public class CreateCloudTagByBlogCommandHandler(IRepository<CloudTagByBlog> _repository) : IRequestHandler<CreateCloudTagByBlogCommand, Unit>
    {
        public async Task<Unit> Handle(CreateCloudTagByBlogCommand request, CancellationToken cancellationToken)
        {
            var value = new CloudTagByBlog
            {
              TagName=request.TagName
            };
            await _repository.CreateAsync(value);
            return Unit.Value;
        }
    }
}