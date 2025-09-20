using DriveNow.Application.Interfaces;
using DriveNow.Domain.Entities;
using MediatR;

namespace DriveNow.Application.Features.Mediator.Handlers.BannerHandlers.BannerWriteHandlers
{
    public class CreateBannerCommandHandler(IRepository<Banner> _repository) : IRequestHandler<CreateBannerCommand, Unit>
    {

        public async Task<Unit> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var values = new Banner
            {

                Title = request.Title,
                VideoDescription = request.VideoDescription,
                Description = request.Description,
                VideoUrl = request.VideoUrl
            };

            await _repository.CreateAsync(values);
            return Unit.Value;
        }
    }
}
