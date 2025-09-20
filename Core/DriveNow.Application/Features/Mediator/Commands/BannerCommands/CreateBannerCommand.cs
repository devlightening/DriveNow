using MediatR;
using System.ComponentModel.DataAnnotations;

public class CreateBannerCommand:IRequest<Unit>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoDescription { get; set; }
    public string VideoUrl { get; set; }
}
