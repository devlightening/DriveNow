using Newtonsoft.Json;
using System;

namespace DriveNow.Dtos.ParagraphDtos
{
    public class ResultBlogSideBarParagraphBoxDto
    {
        [JsonProperty("paragraphId")]
        public Guid ParagraphId { get; set; }

        [JsonProperty("legendName")]
        public string LegendName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("legendDate")]
        public DateTime LegendDate { get; set; }

        [JsonProperty("coverImageUrl")]
        public string CoverImageUrl { get; set; }
    }
}