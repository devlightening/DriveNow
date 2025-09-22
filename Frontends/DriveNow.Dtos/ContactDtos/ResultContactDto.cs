

namespace DriveNow.Dtos.ContactDtos
{
    public class ResultContactDto
    {
        public Guid ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactSubject { get; set; }

        public string ContactMessage { get; set; }

        public DateTime SendDate { get; set; }
    }
}
