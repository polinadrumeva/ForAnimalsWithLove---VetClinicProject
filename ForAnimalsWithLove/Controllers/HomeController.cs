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

		public IActionResult About()
		{
			return View();
		}


		[HttpGet]
		public async Task<IActionResult> TeamVet()
		{
			var doctors = await homeService.GetAllDoctors();
			return View(doctors);
		}

		[HttpGet]
		public async Task<IActionResult> TeamTrainer()
		{
			var trainers = await homeService.GetAllTrainers();
			return View(trainers);
		}

		public IActionResult Halls()
		{
			return View();
		}

		public IActionResult Education()
		{
			return View();
		}

        public IActionResult Hotels()
        {
            return View();
        }

        public IActionResult Grooming()
        {
            return View();
        }

		public async Task<IActionResult> Aboption()
		{
			var animalsForAdoption = await homeService.GetAllForAdoption();
            return View(animalsForAdoption);
        }

        public IActionResult Contact()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}