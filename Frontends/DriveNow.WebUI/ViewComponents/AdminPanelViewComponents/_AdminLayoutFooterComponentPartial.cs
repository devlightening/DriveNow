using Microsoft.AspNetCore.Mvc;

namespace DriveNow.WebUI.ViewComponents.AdminPanelViewComponents
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}