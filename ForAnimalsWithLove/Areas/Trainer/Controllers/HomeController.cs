﻿using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Areas.Trainer.Controllers
{
	public class HomeController : BaseDoctorController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}