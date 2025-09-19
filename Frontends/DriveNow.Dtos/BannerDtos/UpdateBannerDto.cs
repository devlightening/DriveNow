
namespace DriveNow.Dtos.BannerDtos
{
    public class UpdateBannerDto
    {
        public Guid BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
