using DriveNow.Application.Features.Mediator.Commands.BlogCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BlogHandlers.BlogWriteHandlers
{
    public class UpdateBlogCommandHandler(IRepository<Blog> _repository) : IRequestHandler<UpdateBlogCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {

            var Blog = await _repository.GetByIdAsync(request.BlogId);


            if (Blog == null)
            {

                throw new Exception($"Blog with ID {request.BlogId} not found.");
            }


            Blog.AuthorId = request.AuthorId;
            Blog.CoverImageUrl = request.CoverImageUrl;
            Blog.Title = request.Title;
            Blog.CategoryId = request.CategoryId;
            Blog.CreatedDate = request.CreatedDate;



            await _repository.UpdateAsync(Blog);
            return Unit.Value;
        }
    }
}