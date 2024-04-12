using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Areas.Doctor.Controllers
{
	public class HomeController : BaseDoctorController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
