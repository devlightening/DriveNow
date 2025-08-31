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
    public class RemoveCloudTagByBlogCommandHandler(IRepository<CloudTagByBlog> _repository) : IRequestHandler<RemoveCloudTagByBlogCommand, Unit>
    {
        public async Task<Unit> Handle(RemoveCloudTagByBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.CloudTagByBlogId);
            if (value != null)
            {
                await _repository.RemoveAsync(value);

            }
            return Unit.Value;

        }
    }
}