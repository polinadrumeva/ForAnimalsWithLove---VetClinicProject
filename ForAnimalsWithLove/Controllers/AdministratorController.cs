using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Controllers
{
    //Administrator Controller is taking care of the administrator's functionality
    public class AdministratorController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
