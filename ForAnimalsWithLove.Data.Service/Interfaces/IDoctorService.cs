﻿using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;
namespace ForAnimalsWithLove.Data.Service.Interfaces
{
	public interface IDoctorService
	{
		Task<bool> DoctorExistByUserIdAsync(string userId);

		Task<IndexDoctorModel> GetDoctorExistByUserIdAsync(string userId);


		//Animals
		Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
		Task<AdminAnimalModel> GetAnimalByIdAsync(string animalId);
		Task<AdminAnimalModel> GetAnimalModelAsync();
		Task<AdminHealthModel> GetHealthModelAsync();
		Task AddHealthRecordAsync(AdminHealthModel model, string id);
		Task<AdminAnimalModel> GetAnimalDetailsAsync(string id);
		Task<AdminHealthModel> GetHealthRecordDetailsAsync(string id);
		Task<AdminHospitalModel> GetHospitalModelAsync();
		Task AddHospitalRecordAsync(AdminHospitalModel model, string id);
		Task<AdminMedicalModel> GetMedicalModelAsync();
		Task AddMedicalAsync(AdminMedicalModel model, string id);
	}
}