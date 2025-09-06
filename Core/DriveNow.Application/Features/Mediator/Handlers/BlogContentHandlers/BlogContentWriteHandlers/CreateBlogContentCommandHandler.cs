using DriveNow.Application.Features.Mediator.Commands.BlogContentCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;


namespace DriveNow.Application.Features.Mediator.Handlers.BlogContentHandlers.BlogContentWriteHandlers
{
    public class CreateBlogContentCommandHandler(IRepository<BlogContent> _repository) : IRequestHandler<CreateBlogContentCommand, Unit>
    {
        public async Task<Unit> Handle(CreateBlogContentCommand request, CancellationToken cancellationToken)
        {

            var value = new BlogContent
            {
                BlogId = request.BlogId,
                Content = request.Content,
                ContentType = request.ContentType,
                Order = request.Order
            };
            await _repository.CreateAsync(value);
            return Unit.Value;
        }
    }
}
