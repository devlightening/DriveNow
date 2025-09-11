using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.AdminPanelViewComponents
{
    public class _AdminLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}