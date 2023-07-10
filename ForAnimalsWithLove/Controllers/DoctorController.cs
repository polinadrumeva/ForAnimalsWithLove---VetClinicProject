using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Controllers
{
    //Doctor Controller is taking care of the doctor's functionality
    public class DoctorController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
