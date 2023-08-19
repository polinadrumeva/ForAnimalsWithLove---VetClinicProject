using Microsoft.EntityFrameworkCore;

using ForAnimalsWithLove.Data.Service.Interfaces;
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

		public async Task<AdminBookingModel> GetBookingDetailsAsync(string id)
		{
			var book = await dbContext.AnimalsBookings.FirstOrDefaultAsync(a => a.AnimalId.ToString() == id);
			if (book == null)
			{
				return null;
			}
			var booking = await dbContext.Bookings.FirstOrDefaultAsync(a => a.Id == book.BookingId);
			
			if (booking != null)
			{
				return new AdminBookingModel
				{
					StartDate = booking.StartDate,
					EndDate = booking.EndDate,
					Days = booking.Days,
					HotelId = booking.HotelId
				};
			}

			return null;
		}

		public async Task<AdminEducationModel> GetEducationDetailsAsync(string id)
		{
			var educ = await dbContext.AnimalsEducations.FirstOrDefaultAsync(a => a.AnimalId.ToString() == id);
			if (educ == null)
			{
				return null;
			}
			var education = await dbContext.Educations.FirstOrDefaultAsync(a => a.Id == educ.EducationId);
			if (education != null)
			{
				return new AdminEducationModel
				{
					Days = education.Days,
					TrainerId = education.TrainerId.ToString()
				};
			}

			return null;
		}

		public async Task<AdminGroomingModel> GetGroomingAsync(string id)
		{
			var grooming = await dbContext.Groomings.FirstOrDefaultAsync(a => a.AnimalId.ToString() == id);
			if (grooming != null)
			{
				return new AdminGroomingModel
				{
					Service = grooming.Service
				};
			}

			return null;
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

		public async Task<AdminHospitalModel> GetHospitalRecordDetailsAsync(string id)
		{
			var healthRecord =await dbContext.HealthRecords.FirstOrDefaultAsync(a => a.AnimalId.ToString() == id);
			if (healthRecord == null)
			{
				return null;
			}
			var hospitalRecord =await dbContext.HospitalRecords.FirstOrDefaultAsync(a => a.HealthRecordId.ToString() == healthRecord.Id.ToString());
			if (hospitalRecord != null)
			{
				return new AdminHospitalModel
				{
					Diagnosis = hospitalRecord.Diagnosis,
					DateOfAcceptance = hospitalRecord.DateOfAcceptance,
					DateOfDischarge = hospitalRecord.DateOfDischarge,
					Treatment = hospitalRecord.Treatment,	
					PrescribedTreatment = hospitalRecord.PrescribedTreatment,
					HealthRecordId = hospitalRecord.HealthRecordId

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
