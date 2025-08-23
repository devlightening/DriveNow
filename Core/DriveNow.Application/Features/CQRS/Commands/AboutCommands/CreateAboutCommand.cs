using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveNow.Application.Features.CQRS.Commands.AboutCommands
{
    public class CreateAboutCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        //public CreateAboutCommand(string title, string description, string imageUrl)
        //{
        //    Title = title;
        //    Description = description;
        //    ImageUrl = imageUrl;
        //}
    }
}
