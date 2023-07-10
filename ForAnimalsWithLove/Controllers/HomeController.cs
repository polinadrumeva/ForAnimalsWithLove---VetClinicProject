using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using ForAnimalsWithLove.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace ForAnimalsWithLove.Controllers
{

	//Home Controller is the default controller for the application
	[AllowAnonymous]
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
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