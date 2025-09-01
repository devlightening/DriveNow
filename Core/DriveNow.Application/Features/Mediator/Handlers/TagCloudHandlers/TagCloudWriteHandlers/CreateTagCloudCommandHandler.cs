using DriveNow.Application.Features.Mediator.Commands.TagCloudCommands;
using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.TagCloudHandlers.TagCloudWriteHandlers
{
  
    public class CreateTagCloudCommandHandler(IRepository<TagCloud> _repository) : IRequestHandler<CreateTagCloudCommand, Unit>
    {
        public async Task<Unit> Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var value = new TagCloud
            {
                TagCloudName=request.TagCloudName,
                BlogId= request.BlogId

            };
            await _repository.CreateAsync(value);

      
            return Unit.Value;
        }
    }
}