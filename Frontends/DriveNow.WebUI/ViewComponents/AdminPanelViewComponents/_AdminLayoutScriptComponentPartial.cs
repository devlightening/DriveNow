using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.AdminPanelViewComponents
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}