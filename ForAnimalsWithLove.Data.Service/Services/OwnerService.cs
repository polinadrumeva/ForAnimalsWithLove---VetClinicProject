using Microsoft.EntityFrameworkCore;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.IndexModels;
using ForAnimalsWithLove.ViewModels.Admins;

namespace ForAnimalsWithLove.Data.Service.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ForAnimalsWithLoveDbContext dbContext;

        public OwnerService(ForAnimalsWithLoveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task<AdminHealthModel> GetHealthRecordDetailsAsync(string id)
		{
			var healthRecord = await dbContext.HealthRecords.FirstAsync(a => a.AnimalId.ToString() == id);
			if (healthRecord != null)
			{
				return new AdminHealthModel
				{
					Microchip = healthRecord.Microchip,
					MicrochipNumber = healthRecord.MicrochipNumber,
					FirstVaccine = healthRecord.FirstVaccine,
					SecondVaccine = healthRecord.SecondVaccine,
					ThirdVaccine = healthRecord.ThirdVaccine,
					AnnualVaccine = healthRecord.AnnualVaccine,
					GeneralCondition = healthRecord.GeneralCondition,
					PrescribedTreatment = healthRecord.PrescribedTreatment
				};
			}

			return null;
													
		}

		//My Animals
		public async Task<ICollection<AdminAnimalModel>> GetMyAnimalDetailsAsync(string id)
		{
			var animals = await dbContext.Animals.Where(a => a.OwnerId.ToString() == id)
												.Select(a => new AdminAnimalModel
												{ 
													Id = a.Id.ToString(),
													Name = a.Name,
													Age = a.Age,
													Photo = a.Photo,
													KindOfAnimal = a.KindOfAnimal,
													Breed = a.Breed,
													Color = a.Color,
													Sex = a.Sex.ToString(),
													Birthdate = a.Birthdate

												})
												.ToListAsync();

			return animals;
		}

		public async Task<AdminOwnerModel> GetOwnerExistByUserIdAsync(string id)
		{
			var owner = await dbContext.Owners.FirstOrDefaultAsync(o => o.UserId.ToString() == id);
           
            if (owner != null)
            {
				return new AdminOwnerModel
                {
					OwnerId = owner.Id.ToString(),
					FirstName = owner.FirstName,
					MiddleName = owner.MiddleName,
					LastName = owner.LastName,
					PhoneNumber = owner.PhoneNumber,
					Address = owner.Address
				};
			}

			return null;
		}

		public async Task<bool> OwnerExistByUserIdAsync(string userId)
        {
            var result = await dbContext.Owners.AnyAsync(o => o.UserId.ToString() == userId);
            return result;
        }
    }
}
