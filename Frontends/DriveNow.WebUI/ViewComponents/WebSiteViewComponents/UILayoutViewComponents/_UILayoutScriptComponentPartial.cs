using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.WebSiteViewComponents.UILayoutViewComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
