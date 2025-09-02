using DriveNow.Domain.Enums;
using Newtonsoft.Json;

namespace DriveNow.Dtos.BlogContentDtos
{
    public class ResultBlogContentByBlogIdDto
    {
        [JsonProperty("blogContentId")]
        public Guid BlogContentId { get; set; }

        [JsonProperty("blogId")]
        public Guid BlogId { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("contentType")]
        public BlogContentType ContentType { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}