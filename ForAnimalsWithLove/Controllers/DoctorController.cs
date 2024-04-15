using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using ForAnimalsWithLove.Infrastructure.Extensions;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Animals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Controllers
{
	//Doctor Controller is taking care of the doctor's functionality
	[Authorize]
	public class DoctorController : BaseController
    {
		private readonly IDoctorService doctorService;

		public DoctorController(IDoctorService doctorService)
		{
			this.doctorService = doctorService;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> AllAnimals()
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}


			var allAnimals = await doctorService.GetAllAnimals();

			return View(allAnimals);
		}

		[HttpGet]
		public async Task<IActionResult> AllAnimalsFiltred(AllAnimalsQueryModel queryModel)
		{
			var serviceModel = await doctorService.AllAnimalsAsync(queryModel);

			queryModel.Animals = serviceModel.Animals;
			queryModel.TotalAnimals = serviceModel.TotalAnimalsCount;

			return View(queryModel);

		}

		[HttpGet]
		public async Task<IActionResult> AddHealthRecord()
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await doctorService.GetHealthModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddHealthRecord(AdminHealthModel model, string id)
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}


			try
			{
				await doctorService.AddHealthRecordAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimalsFiltred));
		}

		[HttpGet]
		public async Task<IActionResult> HealthRecordDetails(string id)
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await doctorService.GetHealthRecordDetailsAsync(id);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> AddHospitalRecord()
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await doctorService.GetHospitalModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddHospitalRecord(AdminHospitalModel model, string id)
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}

			try
			{
				await doctorService.AddHospitalRecordAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimalsFiltred));
		}

		[HttpGet]
		public async Task<IActionResult> AddMedical()
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await doctorService.GetMedicalModelAsync();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AddMedical(AnimalMedicalModel model, string id)
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}

			try
			{
				await doctorService.AddMedicalAsync(model, id);
			}
			catch (Exception)
			{

				this.ModelState.AddModelError(string.Empty, "Неочаквана грешка! Моля опитайте по-късно или се свържете с администратор!");
				return View(model);
			}


			return RedirectToAction(nameof(AllAnimalsFiltred));
		}

		[HttpGet]
		public async Task<IActionResult> AnimalDetails(string id)
		{
			var isUserDoctor = await doctorService.DoctorExistByUserIdAsync(this.User.GetId()!);
			if (!isUserDoctor && !this.User.IsDoctor())
			{
				return RedirectToAction("Index", "Home");
			}

			var model = await doctorService.GetAnimalDetailsAsync(id);
			return View(model);
		}
	}
}
