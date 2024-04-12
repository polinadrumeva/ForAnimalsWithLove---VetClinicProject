using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ForAnimalsWithLove.Data.Service.Interfaces;
using static ForAnimalsWithLove.Common.AreaConstants;

namespace ForAnimalsWithLove.Controllers
{

	//Home Controller is the default controller for the application
	[AllowAnonymous]
	public class HomeController : BaseController
	{
		private readonly IHomeService homeService;

		public HomeController(IHomeService homeService)
		{
			this.homeService = homeService;
		}

		// Generate Index View page
		public async Task<IActionResult> Index()
		{
			if (this.User.IsInRole(AdminRoleName))
			{
				return this.RedirectToAction("Index", "Home", new { Area = AdminArea });
			}
			else if (this.User.IsInRole(TrainerRoleName))
			{
				return this.RedirectToAction("Index", "Home", new { Area = TrainerArea });
			}

			var counts = await homeService.GetAllCount();
			return View(counts);
		}

		// Generate About View page
		public IActionResult About()
		{
			return View();
		}

		// Generate Halls View page
		public IActionResult Halls()
		{
			return View();
		}

		// Generate Education View page
		public IActionResult Education()
		{
			return View();
		}

		// Generate Hotels View page
		public IActionResult Hotels()
		{
			return View();
		}

		// Generate Grooming View page
		public IActionResult Grooming()
		{
			return View();
		}

		// Generate Contact View page
		public IActionResult Contact()
		{
			return View();
		}

		// Generate Error View page
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 400 || statusCode == 404)
			{
				return View("Error404");
			}

			return View();
		}
	}
}