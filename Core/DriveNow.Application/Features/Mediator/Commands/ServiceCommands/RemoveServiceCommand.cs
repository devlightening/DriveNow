using MediatR;

namespace DriveNow.Application.Features.Mediator.Commands.ServiceCommands
{
    public class RemoveServiceCommand:IRequest<Unit>
    {
        public RemoveServiceCommand(Guid serviceId)
        {
            ServiceId = serviceId;
        }

        public Guid ServiceId { get; set; }

    }
}
