using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Services;
using ForAnimalsWithLove.Infrastructure.Extensions;
using ForAnimalsWithLove.ViewModels.Admins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForAnimalsWithLove.Controllers
{
    //Trainer Controller is taking care of the trainer's functionality
    [Authorize]
    public class TrainerController : BaseController
    {
        private readonly ITrainerService trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            this.trainerService = trainerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllAnimals()
        {
            var isUserTrainer = await trainerService.TrainerExistByUserIdAsync(this.User.GetId()!);
            if (!isUserTrainer && !this.User.IsTrainer())
            {
                return RedirectToAction("Index", "Home");
            }


            var allAnimals = await trainerService.GetAllAnimals();

            return View(allAnimals);
        }

        [HttpGet]
        public async Task<IActionResult> EditAnimal(string id)
        {
            var isUserTrainer = await trainerService.TrainerExistByUserIdAsync(this.User.GetId()!);
            if (!isUserTrainer && !this.User.IsTrainer())
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await trainerService.GetAnimalByIdAsync(id);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> AddEducation()
        {
            var isUserTrainer = await trainerService.TrainerExistByUserIdAsync(this.User.GetId()!);
            if (!isUserTrainer && !this.User.IsTrainer())
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await trainerService.GetEducationModelAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddEducation(AdminEducationModel model, string id)
        {
            var isUserTrainer = await trainerService.TrainerExistByUserIdAsync(this.User.GetId()!);
            if (!isUserTrainer && !this.User.IsTrainer())
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await trainerService.AddEducationAsync(model, id);
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
            var isUserTrainer = await trainerService.TrainerExistByUserIdAsync(this.User.GetId()!);
            if (!isUserTrainer && !this.User.IsTrainer())
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await trainerService.GetHealthRecordDetailsAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AnimalDetails(string id)
        {
            var isUserTrainer = await trainerService.TrainerExistByUserIdAsync(this.User.GetId()!);
            if (!isUserTrainer && !this.User.IsTrainer())
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await trainerService.GetAnimalDetailsAsync(id);
            return View(model);
        }

    }
}
