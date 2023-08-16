using Microsoft.AspNetCore.Mvc;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.Admins;

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

        [HttpGet]
        public async Task<IActionResult> AddAnimals()
        {
			return View();
		}

        public IActionResult AnimalDetails(string id)
        {
            return View(new AdminAnimalModel());
        }

        public async Task<IActionResult> AllDoctors()
        {
            var allDoctors = await adminService.GetAllDoctors();

			return View(allDoctors);
		}

		[HttpGet]
		public async Task<IActionResult> AddDoctor()
		{
			var model = await adminService.GetDoctorModelAsync();
			return View(model);
		}

        [HttpPost]
        public async Task<IActionResult> AddDoctor(AdminDoctorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await adminService.AddDoctorAsync(model);

            return RedirectToAction(nameof(AllDoctors));
        }

		[HttpGet]
		public async Task<IActionResult> EditDoctor(string id)
		{
			var model = await adminService.GetDoctorByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditDoctor(AdminDoctorModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await adminService.EditDoctorAsync(model);

			return RedirectToAction(nameof(AllDoctors));
		}

        [HttpGet]
		public async Task<IActionResult> DoctorDetails(string id)
        {
            var details = await adminService.GetDoctorDetailsAsync(id);

            return View(details);
        }
        public async Task<IActionResult> AllTrainers()
        {
			var allTrainers = await adminService.GetAllTrainers();

            return View(allTrainers);
        }

		[HttpGet]
		public async Task<IActionResult> AddTrainer()
		{
			return View();
		}
	}
}
