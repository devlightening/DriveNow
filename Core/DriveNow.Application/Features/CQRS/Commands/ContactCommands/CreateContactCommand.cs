namespace DriveNow.Application.Features.CQRS.Commands.ContactCommands
{
    public class CreateContactCommand
    {
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime SendDate { get; set; }

        public CreateContactCommand(string contactName, string contactEmail, string contactPhone, string contactSubject, string contactMessage, DateTime sendDate)
        {
            ContactName = contactName;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            ContactSubject = contactSubject;
            ContactMessage = contactMessage;
            SendDate = sendDate;
        }

        public CreateContactCommand() { }
    }
}