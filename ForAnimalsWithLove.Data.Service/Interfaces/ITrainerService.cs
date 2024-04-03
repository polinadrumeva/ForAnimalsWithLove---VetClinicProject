using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface ITrainerService
    {
        Task<bool> TrainerExistByUserIdAsync(string userId);

        Task<IndexTrainerModel> GetTrainerExistByUserIdAsync(string userId);


        //Animals
        Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
        Task<AdminAnimalModel> GetAnimalByIdAsync(string animalId);
        Task<AdminAnimalModel> GetAnimalModelAsync();
        Task<AdminHealthModel> GetHealthModelAsync();

        Task<AdminEducationModel> GetEducationModelAsync();
        Task AddEducationAsync(AdminEducationModel model, string id);
        Task<AdminAnimalModel> GetAnimalDetailsAsync(string id);

    }
}
