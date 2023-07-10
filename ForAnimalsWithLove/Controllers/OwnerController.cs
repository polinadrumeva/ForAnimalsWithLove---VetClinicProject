using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Controllers
{
    //Owner Controller is taking care of the owner's functionality
    public class OwnerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
