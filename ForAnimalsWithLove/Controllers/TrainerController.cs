using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Controllers
{
    //Trainer Controller is taking care of the trainer's functionality
    public class TrainerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
