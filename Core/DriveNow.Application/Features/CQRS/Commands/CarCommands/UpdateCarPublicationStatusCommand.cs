using DriveNow.Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace DriveNow.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarPublicationStatusCommand : IRequest<UpdateCarPublicationStatusResult>
    {
        public Guid CarId { get; set; }
        public bool IsPublished { get; set; } 
    }
}
