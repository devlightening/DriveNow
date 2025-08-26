using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
