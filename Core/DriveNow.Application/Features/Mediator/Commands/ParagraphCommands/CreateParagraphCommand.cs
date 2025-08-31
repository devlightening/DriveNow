using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.Mediator.Commands.ParagraphCommands
{
    public class CreateParagraphCommand :IRequest<Unit>
    {
        public string LegendName { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime LegendDate { get; set; }
    }
}
