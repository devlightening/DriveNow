using DriveNow.Application.Features.Mediator.Commands.TagCloudCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.TagCloudHandlers.TagCloudWriteHandlers
{
    public class RemoveTagCloudCommandHandler(IRepository<TagCloud> _repository) : IRequestHandler<RemoveTagCloudCommand,Unit>
    {
        public async Task<Unit> Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TagCloudId);
            if (value != null)
            {
                await _repository.RemoveAsync(value);   
            }
            return Unit.Value;
            
        }
    }
}
