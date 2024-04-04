using Microsoft.AspNetCore.Mvc;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.Admins;
using Microsoft.AspNetCore.Authorization;
using ForAnimalsWithLove.Infrastructure.Extensions;

namespace ForAnimalsWithLove.Controllers
{
	//Administrator Controller is taking care of the administrator's functionality
	[Authorize]
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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{ 
				return RedirectToAction("Index", "Home");
			}


            var allAnimals = await adminService.GetAllAnimals();

            return View(allAnimals);
        }

        [HttpGet]
        public async Task<IActionResult> AddAnimal()
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetAnimalModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddAnimal(AdminAnimalModel model)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetAnimalByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditAnimal(AdminAnimalModel model)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetHealthModelAsync();
			return View(model);
		}
		

		[HttpGet]
		public async Task<IActionResult> AddGrooming()
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetGroomingModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddGrooming(AdminGroomingModel model, string id)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetEducationModelAsync();
			return View(model);
		}
	

		[HttpGet]
		public async Task<IActionResult> AddBooking()
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetBookingModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddBooking(AdminBookingModel model, string id)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}


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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetSearchHomeModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddSearchHome(AdminSearchHomeModel model, string id)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}


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
		public async Task<IActionResult> AddOwner()
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetOwnerModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddOwner(AdminOwnerModel model, string id)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}


			try
			{
				await adminService.AddOwnerAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimals));
		}

		[HttpGet]
		public async Task<IActionResult> HealthRecordDetails(string id)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetHealthRecordDetailsAsync(id);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> AddHospitalRecord()
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetHospitalModelAsync();
			return View(model);
		}
		
		[HttpGet]
		public async Task<IActionResult> AddMedical()
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetMedicalModelAsync();
			return View(model);
		}
		
		[HttpGet]
		public async Task<IActionResult> AnimalDetails(string id)
        {
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetAnimalDetailsAsync(id);
			return View(model);
        }

        //AllDoctors method is taking care of the functionality of the administrator to see all doctors
        public async Task<IActionResult> AllDoctors()
        {
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var allDoctors = await adminService.GetAllDoctors();

			return View(allDoctors);
		}

		[HttpGet]
		public async Task<IActionResult> AddDoctor()
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetDoctorModelAsync();
			return View(model);
		}

        [HttpPost]
        public async Task<IActionResult> AddDoctor(AdminDoctorModel model)
        {
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetDoctorByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditDoctor(AdminDoctorModel model)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var details = await adminService.GetDoctorDetailsAsync(id);

            return View(details);
        }

        public async Task<IActionResult> RemoveDoctor(string id)
        {
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var allTrainers = await adminService.GetAllTrainers();

            return View(allTrainers);
        }

        
        [HttpGet]
		public async Task<IActionResult> AddTrainer()
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetTrainerModelAsync();
            return View();
		}


		[HttpPost]
		public async Task<IActionResult> AddTrainer(AdminTrainerModel model)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await adminService.GetTrainerByIdAsync(id);
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditTrainer(AdminTrainerModel model)
		{
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
			var isUserAdmin = await adminService.AdminExistByUserIdAsync(this.User.GetId()!);
			if (!isUserAdmin && !this.User.IsAdmin())
			{
				return RedirectToAction("Index", "Home");
			}

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
