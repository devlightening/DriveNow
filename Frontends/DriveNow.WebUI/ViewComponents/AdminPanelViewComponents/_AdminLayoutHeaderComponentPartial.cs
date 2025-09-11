using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.AdminPanelViewComponents
{
    public class _AdminLayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}