﻿using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
	public interface IOwnerService
	{
		Task<bool> OwnerExistByUserIdAsync(string userId);

		//My Animals
		Task<AdminOwnerModel> GetOwnerExistByUserIdAsync(string id);
		Task<ICollection<AdminAnimalModel>> GetMyAnimalDetailsAsync(string id);
		Task<AdminHealthModel> GetHealthRecordDetailsAsync(string id);
		Task<AdminHealthModel> GetHospitalRecordDetailsAsync(string id);
		Task<AdminGroomingModel> GetGroomingAsync(string id);
		Task<AdminAnimalModel> GetBookingDetailsAsync(string id);
		Task<AdminEducationModel> GetEducationDetailsAsync(string id);
	}
}