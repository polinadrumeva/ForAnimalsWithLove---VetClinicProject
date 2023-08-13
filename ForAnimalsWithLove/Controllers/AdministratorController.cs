using Microsoft.AspNetCore.Mvc;

using ForAnimalsWithLove.Data.Service.Interfaces;

namespace ForAnimalsWithLove.Controllers
{
    //Administrator Controller is taking care of the administrator's functionality
    public class AdministratorController : BaseController
    {
        private readonly IAdminService adminService;

        public AdministratorController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllAnimals()
        {
            var allAnimals = await adminService.GetAllAnimals();

            return View(allAnimals);
        }

        public async Task<IActionResult> Details()
        {
            var allAnimals = await adminService.GetAllAnimals();

            return View(allAnimals);
        }

        public async Task<IActionResult> AllDoctors()
        {
            var allDoctors = await adminService.GetAllDoctors();

			return View(allDoctors);
		}
		
        public async Task<IActionResult> AllTrainers()
        {
			var allTrainers = await adminService.GetAllTrainers();

            return View(allTrainers);
        }
    }
}
