using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
