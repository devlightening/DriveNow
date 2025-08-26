using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
