using DriveNow.Application.Features.Mediator.Commands.BlogCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogWriteHandlers
{
    public class CreateBlogCommandHandler(IRepository<Blog> _repository) : IRequestHandler<CreateBlogCommand, Unit>
    {
        public async Task<Unit> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var values = new Blog
            {
                AuthorId = request.AuthorId,
                Title = request.Title,
                CreatedDate = request.CreatedDate,
                CoverImageUrl = request.CoverImageUrl,
                CategoryId = request.CategoryId,
            };

            await _repository.CreateAsync(values);
            return Unit.Value;
        }
    }
}