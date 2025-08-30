using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailMainCompenentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}