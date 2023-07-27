using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using ForAnimalsWithLove.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ForAnimalsWithLove.Data.Service.Interfaces;

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

		public async Task<IActionResult> Index()
		{
            var counts = await homeService.GetAllCount();
            return View(counts);
		}

		public async Task<IActionResult> About()
		{
			return View();
		}

		public async Task<IActionResult> Contact()
		{
            return View();
        }

		public async Task<IActionResult> Team()
		{
			var doctors = await homeService.GetAllDoctors();
			return View(doctors);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}