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

        //AllAnimals method is taking care of the functionality of the administrator to see all animals
        public async Task<IActionResult> AllAnimals()
        {
            var allAnimals = await adminService.GetAllAnimals();

            return View(allAnimals);
        }

        [HttpGet]
        public async Task<IActionResult> AddAnimal()
		{
			var model = await adminService.GetAnimalModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddAnimal(AdminAnimalModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await adminService.AddAnimalAsync(model);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimals));
		}

		[HttpGet]
		public async Task<IActionResult> EditAnimal(string id)
		{
			var model = await adminService.GetAnimalByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditAnimal(AdminAnimalModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await adminService.EditAnimalAsync(model);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimals));
		}

		[HttpGet]
		public async Task<IActionResult> AddHealthRecord()
		{
			var model = await adminService.GetHealthModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddHealthRecord(AdminHealthModel model, string id)
		{
			
			try
			{
				await adminService.AddHealthRecordAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimals));
		}


		[HttpGet]
		public async Task<IActionResult> AddGrooming()
		{
			var model = await adminService.GetGroomingModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddGrooming(AdminGroomingModel model, string id)
		{

			try
			{
				await adminService.AddGroomingAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimals));
		}

		[HttpGet]
		public async Task<IActionResult> AddEducation()
		{
			var model = await adminService.GetEducationModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddEducation(AdminEducationModel model, string id)
		{

			try
			{
				await adminService.AddEducationAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimals));
		}

		[HttpGet]
		public async Task<IActionResult> AddBooking()
		{
			var model = await adminService.GetBookingModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddBooking(AdminBookingModel model, string id)
		{

			try
			{
				await adminService.AddBookingAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimals));
		}

		[HttpGet]
		public async Task<IActionResult> AddSearchHome()
		{
			var model = await adminService.GetSearchHomeModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddSearchHome(AdminSearchHomeModel model, string id)
		{


			try
			{
				await adminService.AddSearchHomeAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimals));
		}

		[HttpGet]
		public async Task<IActionResult> AnimalDetails(string id)
        {
           var model = await adminService.GetAnimalDetailsAsync(id);
			return View(model);
        }

        //AllDoctors method is taking care of the functionality of the administrator to see all doctors
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

			try
			{
                await adminService.AddDoctorAsync(model);
            }
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
                return View(model);
            }

            

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

			try
			{
                await adminService.EditDoctorAsync(model);
            }
			catch (Exception)
			{
                this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
                return View(model);
            }
			

			return RedirectToAction(nameof(AllDoctors));
		}

        [HttpGet]
		public async Task<IActionResult> DoctorDetails(string id)
        {
            var details = await adminService.GetDoctorDetailsAsync(id);

            return View(details);
        }

        public async Task<IActionResult> RemoveDoctor(string id)
        {
            var doctor = await adminService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return RedirectToAction(nameof(AllDoctors));
            }


            await adminService.RemoveDoctorAsync(doctor, id);

            return RedirectToAction(nameof(AllDoctors));
        }


        //AllTrainers method is taking care of the functionality of the administrator to see all trainers
        public async Task<IActionResult> AllTrainers()
        {
			var allTrainers = await adminService.GetAllTrainers();

            return View(allTrainers);
        }

        
        [HttpGet]
		public async Task<IActionResult> AddTrainer()
		{
            var model = await adminService.GetTrainerModelAsync();
            return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddTrainer(AdminTrainerModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
                await adminService.AddTrainerAsync(model);
            }
			catch (Exception)
			{

                this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
                return View(model);
            }
			

			return RedirectToAction(nameof(AllTrainers));
		}

		[HttpGet]
		public async Task<IActionResult> EditTrainer(string id)
		{
			var model = await adminService.GetTrainerByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditTrainer(AdminTrainerModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
                await adminService.EditTrainerAsync(model);
            }
			catch (Exception)
			{
                this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
                return View(model);
            }

			

			return RedirectToAction(nameof(AllTrainers));
		}

		public async Task<IActionResult> RemoveTrainer(string id)
		{
			var trainer = await adminService.GetTrainerByIdAsync(id);

			if (trainer == null)
			{
				return RedirectToAction(nameof(AllTrainers));
			}


			await adminService.RemoveTrainerAsync(trainer, id);

			return RedirectToAction(nameof(AllTrainers));
		}
	}
}
