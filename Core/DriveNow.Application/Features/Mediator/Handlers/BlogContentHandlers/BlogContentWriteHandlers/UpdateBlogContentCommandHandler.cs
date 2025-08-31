using DriveNow.Application.Features.Mediator.Commands.BlogContentCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogContentHandlers.BlogContentWriteHandlers
{
    public class UpdateBlogContentCommandHandler(IRepository<BlogContent> _repository) : IRequestHandler<UpdateBlogContentCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateBlogContentCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogContentId);
            if (value == null)
            {
                throw new ArgumentException("BlogContent not found");
            }
            value.Content = request.Content;
            value.BlogId = request.BlogId;
            value.ContentType = request.ContentType;
            value.Order = request.Order;

            await _repository.UpdateAsync(value);
            return Unit.Value;

        }
    }
}
