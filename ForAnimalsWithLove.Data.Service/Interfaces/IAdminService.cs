using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
		Task<IEnumerable<IndexDoctorModel>> GetAllDoctors();
		Task<AdminDoctorModel> GetDoctorModelAsync();
		Task AddDoctorAsync(AdminDoctorModel model);
		Task<AdminDoctorModel?> GetDoctorByIdAsync(string id);
		Task EditDoctorAsync(AdminDoctorModel model);
		Task<AdminDoctorModel> GetDoctorDetailsAsync(string doctorId);
        Task RemoveDoctorAsync(AdminDoctorModel model, string id);
        Task<IEnumerable<IndexTrainerModel>> GetAllTrainers();

        Task<AdminAnimalModel> GetAnimalById(string animalId);
    }
}
