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
    public class UpdateCloudTagByBlogCommandHandler(IRepository<CloudTagByBlog> _repository) : IRequestHandler<UpdateCloudTagByBlogCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateCloudTagByBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CloudTagByBlogId);
            if (value == null)
            {
                throw new ArgumentException("CloudTagByBlog not found");
            }
            value.TagName = request.TagName;
            await _repository.UpdateAsync(value);
            return Unit.Value;

        }
    }
}
