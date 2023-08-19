using Microsoft.AspNetCore.Mvc;

using ForAnimalsWithLove.Data.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ForAnimalsWithLove.Controllers
{
    //Owner Controller is taking care of the owner's functionality
    [Authorize]
    public class OwnerController : BaseController
    {
        private readonly IOwnerService ownerService;

        public OwnerController(IOwnerService ownerService)
        {
             this.ownerService = ownerService;
        }


		[HttpGet]
		public async Task<IActionResult> MyAnimalDetails(string id)
		{
            var doesHaveAnimal = await ownerService.OwnerExistByUserIdAsync(id);
            if (!doesHaveAnimal)
            {
				return RedirectToAction("Index", "Home");
			}

            var owner = await ownerService.GetOwnerExistByUserIdAsync(id);
			var model = await ownerService.GetMyAnimalDetailsAsync(owner.OwnerId);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> HealthRecordDetails(string id)
		{
			var model = await ownerService.GetHealthRecordDetailsAsync(id);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> HospitalRecordDetails(string id)
		{
			var doesHaveAnimal = await ownerService.OwnerExistByUserIdAsync(id);
			if (!doesHaveAnimal)
			{
				return RedirectToAction("Index", "Home");
			}

			var owner = await ownerService.GetOwnerExistByUserIdAsync(id);
			var model = await ownerService.GetMyAnimalDetailsAsync(owner.OwnerId);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GroomingDetails(string id)
		{
			var doesHaveAnimal = await ownerService.OwnerExistByUserIdAsync(id);
			if (!doesHaveAnimal)
			{
				return RedirectToAction("Index", "Home");
			}

			var owner = await ownerService.GetOwnerExistByUserIdAsync(id);
			var model = await ownerService.GetMyAnimalDetailsAsync(owner.OwnerId);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> BookingDetails(string id)
		{
			var doesHaveAnimal = await ownerService.OwnerExistByUserIdAsync(id);
			if (!doesHaveAnimal)
			{
				return RedirectToAction("Index", "Home");
			}

			var owner = await ownerService.GetOwnerExistByUserIdAsync(id);
			var model = await ownerService.GetMyAnimalDetailsAsync(owner.OwnerId);
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> EducationDetails(string id)
		{
			var doesHaveAnimal = await ownerService.OwnerExistByUserIdAsync(id);
			if (!doesHaveAnimal)
			{
				return RedirectToAction("Index", "Home");
			}

			var owner = await ownerService.GetOwnerExistByUserIdAsync(id);
			var model = await ownerService.GetMyAnimalDetailsAsync(owner.OwnerId);
			return View(model);
		}
	}
}
