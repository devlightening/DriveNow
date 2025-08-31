using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Results.ParagraphResults
{
    public class GetParagraphQueryResult
    {
        public GetParagraphQueryResult(Guid paragraphId, string legendName, string description, DateTime legendDate, string coverImageUrl)
        {
            ParagraphId = paragraphId;
            LegendName = legendName;
            Description = description;
            LegendDate = legendDate;
            CoverImageUrl = coverImageUrl;
        }

        public Guid ParagraphId { get; set; }
        public string LegendName { get; set; }
        public string Description { get; set; }
        public DateTime LegendDate { get; set; }
        public string CoverImageUrl { get; set; }


    }
}
