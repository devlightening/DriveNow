using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.WebSiteViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}