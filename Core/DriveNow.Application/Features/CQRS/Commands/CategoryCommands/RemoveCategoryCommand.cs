using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveCategoryCommand
    {
        public Guid CategoryId { get; set; }
        public RemoveCategoryCommand(Guid categoryId)
        {
            CategoryId = categoryId;
        }

    }
}
