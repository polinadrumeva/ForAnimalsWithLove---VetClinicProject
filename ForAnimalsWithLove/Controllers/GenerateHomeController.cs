using ForAnimalsWithLove.Data.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Controllers
{
	[AllowAnonymous]
	public class GenerateHomeController : BaseController
	{
		private readonly IHomeService homeService;

		public GenerateHomeController(IHomeService homeService)
		{
			this.homeService = homeService;
		}


		// Generate Team Veterinarian View page
		[HttpGet]
		public async Task<IActionResult> TeamVet()
		{
			var doctors = await homeService.GetAllDoctors();
			return View(doctors);
		}

		// Generate Team Trainer View page
		[HttpGet]
		public async Task<IActionResult> TeamTrainer()
		{
			var trainers = await homeService.GetAllTrainers();
			return View(trainers);
		}

		// Generate Adoption View page
		public async Task<IActionResult> Aboption()
		{
			var animalsForAdoption = await homeService.GetAllForAdoption();
			return View(animalsForAdoption);
		}

	}
}
