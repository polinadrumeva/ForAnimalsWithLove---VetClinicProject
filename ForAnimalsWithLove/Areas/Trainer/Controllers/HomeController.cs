using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Areas.Trainer.Controllers
{
	public class HomeController : BaseTrainerController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
