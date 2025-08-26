using MediatR;

namespace DriveNow.Application.Features.Mediator.Commands.ServiceCommands
{
    public class CreateServiceCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
