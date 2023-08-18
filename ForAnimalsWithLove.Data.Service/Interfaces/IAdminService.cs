using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
		Task<AdminAnimalModel> GetAnimalByIdAsync(string animalId);
		Task<AdminAnimalModel> GetAnimalModelAsync();
		Task EditAnimalAsync(AdminAnimalModel model);
		Task AddAnimalAsync(AdminAnimalModel model);
		Task<AdminHealthModel> GetHealthModelAsync();
		Task AddHealthRecordAsync(AdminHealthModel model, string id);

		Task<AdminGroomingModel> GetGroomingModelAsync();
		Task AddGroomingAsync(AdminGroomingModel model, string id);
		Task<AdminEducationModel> GetEducationModelAsync();
		Task AddEducationAsync(AdminEducationModel model, string id);

		//Doctors
		Task<IEnumerable<IndexDoctorModel>> GetAllDoctors();
		Task<AdminDoctorModel> GetDoctorModelAsync();
		Task AddDoctorAsync(AdminDoctorModel model);
		Task<AdminDoctorModel?> GetDoctorByIdAsync(string id);
		Task EditDoctorAsync(AdminDoctorModel model);
		Task<AdminDoctorModel> GetDoctorDetailsAsync(string doctorId);
        Task RemoveDoctorAsync(AdminDoctorModel model, string id);

        //Trainers
        Task<IEnumerable<IndexTrainerModel>> GetAllTrainers();
        Task<AdminTrainerModel> GetTrainerModelAsync();
        Task AddTrainerAsync(AdminTrainerModel model);
		Task<AdminTrainerModel?> GetTrainerByIdAsync(string id);
		Task EditTrainerAsync(AdminTrainerModel model);
		Task RemoveTrainerAsync(AdminTrainerModel model, string id);

	}
}
