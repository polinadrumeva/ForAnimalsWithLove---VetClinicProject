using Microsoft.EntityFrameworkCore;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Animals;

namespace ForAnimalsWithLove.Data.Service.Services
{
	public class OwnerService : IOwnerService

	{
		private readonly ForAnimalsWithLoveDbContext dbContext;

		public OwnerService(ForAnimalsWithLoveDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<AdminAnimalModel> GetBookingDetailsAsync(string id)
		{
			var animal = await dbContext.Animals.FirstAsync(x => x.Id.ToString() == id);
			var bookings = await dbContext.AnimalsBookings
					.Include(x => x.Booking)
					.Where(x => x.AnimalId == animal.Id)
					.Select(x => new AdminBookingModel
					{
						StartDate = x.Booking.StartDate,
						EndDate = x.Booking.EndDate,
						Days = x.Booking.Days,
						HotelName = x.Booking.Hotel.Name
					})
					.OrderByDescending(x => x.EndDate)
					.ToArrayAsync();

			if (bookings.Length != 0)
			{
				return new AdminAnimalModel()
				{
					Id = animal.Id.ToString(),
					Bookings = bookings
				};
			}

			return null!;
		}
		public async Task<AdminEducationModel> GetEducationDetailsAsync(string id)
		{
			var educ = await dbContext.AnimalsEducations.FirstOrDefaultAsync(a => a.AnimalId.ToString() == id);
			if (educ == null)
			{
				return null!;
			}
			var education = await dbContext.Educations.FirstOrDefaultAsync(a => a.Id == educ.EducationId);
			var trainer = await dbContext.Trainers.FirstOrDefaultAsync(a => a.Id == education.TrainerId);
			if (education != null)
			{
				return new AdminEducationModel
				{
					Days = education.Days,
					TrainerId = education.TrainerId.ToString(),
					Trainer = new AdminTrainerModel
					{
						FirstName = trainer.FirstName,
						LastName = trainer.LastName
					}
				};
			}

			return null!;
		}

		public async Task<AdminGroomingModel> GetGroomingAsync(string id)
		{
			var grooming = await dbContext.Groomings.FirstOrDefaultAsync(a => a.AnimalId.ToString() == id);
			if (grooming != null)
			{
				return new AdminGroomingModel
				{
					Service = grooming.Service,
					Date = grooming.Date
				};
			}

			return null!;
		}

		public async Task<AdminHealthModel> GetHealthRecordDetailsAsync(string id)
		{
			var healthRecord = await dbContext.HealthRecords.FirstAsync(x => x.AnimalId.ToString() == id);
			var medicals = await dbContext.Medicals
					.Where(x => x.HealthRecordId == healthRecord.Id)
					.Select(x => new AnimalMedicalModel
					{
						Date = x.Date,
						DoctorFirstName = x.Doctor.FirstName,
						DoctorLastName = x.Doctor.LastName,
						Reason = x.Reason,
						Constatation = x.Constatation,
						PrescribedTreatment = x.PrescribedTreatment
					})
					.OrderByDescending(x => x.Date)
					.ToArrayAsync();

			return new AdminHealthModel()
			{
				Id = healthRecord.Id.ToString(),
				AnimalId = healthRecord.AnimalId.ToString(),
				Microchip = healthRecord.Microchip,
				MicrochipNumber = healthRecord.MicrochipNumber,
				FirstVaccine = healthRecord.FirstVaccine,
				SecondVaccine = healthRecord.SecondVaccine,
				ThirdVaccine = healthRecord.ThirdVaccine,
				AnnualVaccine = healthRecord.AnnualVaccine,
				GeneralCondition = healthRecord.GeneralCondition,
				Medicals = medicals
			};
		}

		public async Task<AdminHealthModel> GetHospitalRecordDetailsAsync(string id)
		{
			var healthRecord = await dbContext.HealthRecords.FirstOrDefaultAsync(x => x.AnimalId.ToString() == id);
			
			var records = await dbContext.HospitalRecords
					.Where(x => x.HealthRecordId == healthRecord.Id)
					.Select(x => new AdminHospitalModel
					{
						DateOfAcceptance = x.DateOfAcceptance,
						DateOfDischarge = x.DateOfDischarge,
						Diagnosis = x.Diagnosis,
						Treatment = x.Treatment,
						PrescribedTreatment = x.PrescribedTreatment
					})
					.OrderByDescending(x => x.DateOfDischarge)
					.ToArrayAsync();

			if (records.Length == 0)
			{
				return null!;
			}
			return new AdminHealthModel()
			{
				Id = healthRecord.Id.ToString(),
				AnimalId = healthRecord.AnimalId.ToString(),
				HospitalRecords = records
			};

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

			return null!;
		}

		public async Task<bool> OwnerExistByUserIdAsync(string userId)
		{
			var result = await dbContext.Owners.AnyAsync(o => o.UserId.ToString() == userId);
			return result;
		}
	}
}