using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
