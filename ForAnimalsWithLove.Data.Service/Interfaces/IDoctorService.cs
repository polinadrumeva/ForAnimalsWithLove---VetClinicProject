using ForAnimalsWithLove.Data.Service.Model;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Animals;
using ForAnimalsWithLove.ViewModels.IndexModels;
namespace ForAnimalsWithLove.Data.Service.Interfaces
{
	public interface IDoctorService
	{
		Task<bool> DoctorExistByUserIdAsync(string userId);

		Task<IndexDoctorModel> GetDoctorExistByUserIdAsync(string userId);


		//Animals
		Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
		Task<AllAnimalsFiltredServiceModel> AllAnimalsAsync(AllAnimalsQueryModel queryModel);
		Task<AdminAnimalModel> GetAnimalByIdAsync(string animalId);
		Task<AdminHealthModel> GetHealthRecordByIdAsync(string healthId);
		Task<AdminAnimalModel> GetAnimalModelAsync();
		Task<AdminHealthModel> GetHealthModelAsync();
		Task EditHealthRecordAsync(AdminHealthModel model);
		Task AddHealthRecordAsync(AdminHealthModel model, string id);
		Task<AdminAnimalModel> GetAnimalDetailsAsync(string id);
		Task<AdminHealthModel> GetHealthRecordDetailsAsync(string id);
		Task<AdminHospitalModel> GetHospitalModelAsync();
		Task AddHospitalRecordAsync(AdminHospitalModel model, string id);
		Task<AnimalMedicalModel> GetMedicalModelAsync();
		Task AddMedicalAsync(AnimalMedicalModel model, string id);
	}
}