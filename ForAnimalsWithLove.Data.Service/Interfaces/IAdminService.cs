using ForAnimalsWithLove.Data.Service.Model;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Animals;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
	public interface IAdminService
	{
		Task<bool> AdminExistByUserIdAsync(string userId);

		Task<AdminIndexModel> GetAdminExistByUserIdAsync(string userId);


		//Animals
		Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
		Task<AllAnimalsFiltredServiceModel> AllAnimalsAsync(AllAnimalsQueryModel queryModel);
		Task<AdminAnimalModel> GetAnimalByIdAsync(string animalId);
		Task<AdminAnimalModel> GetAnimalModelAsync();
		Task EditAnimalAsync(AdminAnimalModel model);
		Task AddAnimalAsync(AdminAnimalModel model);
		Task<AdminHealthModel> GetHealthModelAsync();
		Task EditGroomingAsync(AdminGroomingModel model);
		Task<AdminGroomingModel> GetGroomingDetailsAsync(string id);
		Task<AdminGroomingModel> GetGroomingModelAsync();
		Task AddGroomingAsync(AdminGroomingModel model, string id);
		Task<AdminEducationModel> GetEducationModelAsync();
		Task<AdminBookingModel> GetBookingModelAsync();
		Task<AdminAnimalModel> GetBookingDetailsAsync(string id);
		Task AddBookingAsync(AdminBookingModel model, string id);
		Task<AdminSearchHomeModel> GetSearchHomeModelAsync();
		Task AddSearchHomeAsync(AdminSearchHomeModel model, string id);
		Task<AdminAnimalModel> GetAnimalDetailsAsync(string id);
		Task<AdminOwnerModel> GetOwnerModelAsync();
		Task AddOwnerAsync(AdminOwnerModel model, string id);
		Task<AdminHealthModel> GetHealthRecordDetailsAsync(string id);
		Task<AdminHospitalModel> GetHospitalModelAsync();
		Task<AdminMedicalModel> GetMedicalModelAsync();

		//Doctors
		Task<IEnumerable<IndexDoctorModel>> GetAllDoctors();
		Task<AllDoctorsFiltredServiceModel> GetAllDoctorsFiltredServiceModelAsync(AllDoctorsQueryModel queryModel);

		Task<IEnumerable<string>> AllDirectionsNamesAsync();
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