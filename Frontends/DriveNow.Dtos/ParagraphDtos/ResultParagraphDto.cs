
namespace DriveNow.Dtos.ParagraphDtos
{
    public class ResultParagraphDto
    {
        public Guid ParagraphId { get; set; }
        public string LegendName { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime LegendDate { get; set; }
    }
}
