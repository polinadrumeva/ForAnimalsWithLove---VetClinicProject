using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
		Task<IEnumerable<IndexDoctorModel>> GetAllDoctors();
        Task AddDoctorAsync(string userId, AdminDoctorModel model);
        Task<IEnumerable<IndexTrainerModel>> GetAllTrainers();

        Task<AdminAnimalModel> GetAnimalById(string animalId);
    }
}
