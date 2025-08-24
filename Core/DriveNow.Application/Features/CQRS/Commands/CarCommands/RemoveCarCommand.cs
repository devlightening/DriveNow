namespace DriveNow.Application.Features.CQRS.Commands.CarCommands
{
    public class RemoveCarCommand
    {
        public Guid Id { get; set; }

        public RemoveCarCommand(Guid id)
        {
            Id = id;
        }
    }
}