using ForAnimalsWithLove.Data.Service.Model;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Animals;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface ITrainerService
    {
        Task<bool> TrainerExistByUserIdAsync(string userId);

        Task<IndexTrainerModel> GetTrainerExistByUserIdAsync(string userId);


        //Animals
        Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
		Task<AllAnimalsFiltredServiceModel> AllAnimalsAsync(AllAnimalsQueryModel queryModel);
		Task<AdminAnimalModel> GetAnimalByIdAsync(string animalId);
        Task<AdminAnimalModel> GetAnimalModelAsync();
        Task<AdminHealthModel> GetHealthModelAsync();

        Task<AdminEducationModel> GetEducationModelAsync();
        Task AddEducationAsync(AdminEducationModel model, string id);
        Task<AdminAnimalModel> GetAnimalDetailsAsync(string id);
        Task<AdminHealthModel> GetHealthRecordDetailsAsync(string id);

    }
}
