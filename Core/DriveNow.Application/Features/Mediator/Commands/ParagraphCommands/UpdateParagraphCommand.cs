using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.ParagraphCommands
{
    public class UpdateParagraphCommand:IRequest<Unit>
    {
        public Guid ParagraphId { get; set; }
        public string LegendName { get; set; }
        public string Description { get; set; }
        public DateTime LegendDate { get; set; }
        public string CoverImageUrl { get; set; }


    }
}
