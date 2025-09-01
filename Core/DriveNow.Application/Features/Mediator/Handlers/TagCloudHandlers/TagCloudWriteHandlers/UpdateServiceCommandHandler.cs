using DriveNow.Application.Features.Mediator.Commands.TagCloudCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.TagCloudHandlers.TagCloudWriteHandlers
{
    public class UpdateTagCloudCommandHandler(IRepository<TagCloud> _repository) : IRequestHandler<UpdateTagCloudCommand,Unit>
    {
        public async Task<Unit> Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.TagCloudId);
            if (value == null)
            {
                throw new Exception("TagCloud is not Found");
            }
            value.TagCloudName = request.TagCloudName;
            value.BlogId = request.BlogId;
            await _repository.UpdateAsync(value);
            return Unit.Value;
        }
        
    }
}
