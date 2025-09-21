using DriveNow.Application.Features.Mediator.Commands.BlogCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

public class ToggleBlogPublishCommandHandler(IRepository<Blog> _repo) : IRequestHandler<ToggleBlogPublishCommand, bool>
{
    public async Task<bool> Handle(ToggleBlogPublishCommand request, CancellationToken cancellationToken)
    {
        var blog = await _repo.GetByIdAsync(request.BlogId);
        if (blog == null)
            throw new KeyNotFoundException("Blog not found");

        blog.IsPublished = !blog.IsPublished;
        await _repo.UpdateAsync(blog);

        return blog.IsPublished;
    }
}
