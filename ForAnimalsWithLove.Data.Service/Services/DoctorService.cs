using ForAnimalsWithLove.Data.Models;
using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;
using Microsoft.EntityFrameworkCore;


namespace ForAnimalsWithLove.Data.Service.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly ForAnimalsWithLoveDbContext dbContext;

		public DoctorService(ForAnimalsWithLoveDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<bool> DoctorExistByUserIdAsync(string userId)
		{
			var result = await dbContext.Doctors.AnyAsync(x => x.UserId.ToString() == userId);

			return result;
		}

		public async Task<IndexDoctorModel> GetDoctorExistByUserIdAsync(string id)
		{
			var doctor = await dbContext.Doctors.FirstOrDefaultAsync(o => o.UserId.ToString() == id);

			if (doctor != null)
			{
				return new IndexDoctorModel
				{
					Id = doctor.Id.ToString(),
					FirstName = doctor.FirstName
				};
				
			}

			return null;
		}

		//Animals
		public async Task<IEnumerable<AdminAnimalModel>> GetAllAnimals()
		{

			var result = await dbContext.Animals
								  .Select(a => new AdminAnimalModel()
								  {
									  Id = a.Id.ToString(),
									  Name = a.Name,
									  Age = a.Age,
									  Photo = a.Photo,
									  KindOfAnimal = a.KindOfAnimal,
									  Breed = a.Breed,
									  Color = a.Color,
									  Birthdate = a.Birthdate,
									  Sex = a.Sex.ToString(),
									  DoesHasOwner = a.DoesHasOwner,
									  OwnerId = a.OwnerId.ToString(),
									  Owner = new AdminOwnerModel()
									  {
										  FirstName = a.Owner.FirstName,
										  MiddleName = a.Owner.MiddleName,
										  LastName = a.Owner.LastName,
										  Address = a.Owner.Address,
										  PhoneNumber = a.Owner.PhoneNumber
									  }

								  }).ToListAsync();

			return result;
		}

		public async Task<AdminAnimalModel?> GetAnimalByIdAsync(string animalId)
		{
			return await dbContext.Animals.Where(x => x.Id.ToString() == animalId)
				.Select(x => new AdminAnimalModel
				{
					Name = x.Name,
					Age = x.Age,
					Photo = x.Photo,
					KindOfAnimal = x.KindOfAnimal,
					Breed = x.Breed,
					Color = x.Color,
					Birthdate = x.Birthdate,
					Sex = x.Sex.ToString(),
					DoesHasOwner = x.DoesHasOwner

				}).FirstOrDefaultAsync();
		}
		public async Task<AdminAnimalModel> GetAnimalModelAsync()
		{
			var model = new AdminAnimalModel();

			return model;
		}

		public async Task<AdminHealthModel> GetHealthModelAsync()
		{
			var model = new AdminHealthModel();

			return model;
		}

		public async Task AddHealthRecordAsync(AdminHealthModel model, string id)
		{
			var healthRecord = new HealthRecord
			{
				Id = Guid.NewGuid(),
				AnimalId = Guid.Parse(id),
				Animal = dbContext.Animals.FirstOrDefault(x => x.Id.ToString() == id),
				Microchip = model.Microchip,
				MicrochipNumber = model.MicrochipNumber,
				FirstVaccine = model.FirstVaccine,
				SecondVaccine = model.SecondVaccine,
				ThirdVaccine = model.ThirdVaccine,
				AnnualVaccine = model.AnnualVaccine,
				GeneralCondition = model.GeneralCondition,
				PrescribedTreatment = model.PrescribedTreatment

			};

			var animal = await dbContext.Animals.FirstOrDefaultAsync(x => x.Id.ToString() == id);
			animal.HealthRecordId = healthRecord.Id;

			await dbContext.HealthRecords.AddAsync(healthRecord);
			await dbContext.SaveChangesAsync();
		}

		public async Task<AdminAnimalModel> GetAnimalDetailsAsync(string id)
		{
			var animal = await dbContext.Animals.FirstAsync(x => x.Id.ToString() == id);

			return new AdminAnimalModel()
			{
				Id = animal.Id.ToString(),
				Name = animal.Name,
				Age = animal.Age,
				Photo = animal.Photo,
				KindOfAnimal = animal.KindOfAnimal,
				Breed = animal.Breed,
				Color = animal.Color,
				Sex = animal.Sex.ToString(),
				Birthdate = animal.Birthdate
			};

		}

		public async Task<AdminHealthModel> GetHealthRecordDetailsAsync(string id)
		{
			var healthRecord = await dbContext.HealthRecords.FirstAsync(x => x.AnimalId.ToString() == id);

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
				PrescribedTreatment = healthRecord.PrescribedTreatment
			};
		}
		public async Task<AdminHospitalModel> GetHospitalModelAsync()
		{
			var hospitalRecord = new AdminHospitalModel();
			return hospitalRecord;
		}

		public async Task AddHospitalRecordAsync(AdminHospitalModel model, string id)
		{
			var hospitalRecord = new HospitalRecord
			{
				Id = Guid.NewGuid(),
				HealthRecordId = Guid.Parse(id),
				HealthRecord = dbContext.HealthRecords.FirstOrDefault(x => x.Id.ToString() == id),
				Diagnosis = model.Diagnosis,
				DateOfAcceptance = model.DateOfAcceptance,
				DateOfDischarge = model.DateOfDischarge,
				Treatment = model.Treatment,
				PrescribedTreatment = model.PrescribedTreatment
			};


			var healthRecord = await dbContext.HealthRecords.FirstOrDefaultAsync(x => x.Id.ToString() == id);
			healthRecord.HospitalRecordId = hospitalRecord.Id;
			healthRecord.HospitalRecord = hospitalRecord;

			await dbContext.HospitalRecords.AddAsync(hospitalRecord);
			await dbContext.SaveChangesAsync();

		}

		public async Task<AdminMedicalModel> GetMedicalModelAsync()
		{
			var doctors = await dbContext.Doctors
				.Select(x => new AdminDoctorModel
				{
					Id = x.Id.ToString(),
					FirstName = x.FirstName,
					LastName = x.LastName
				})
				.ToListAsync();

			var model = new AdminMedicalModel
			{
				Doctors = doctors
			};

			return model;
		}

		public async Task AddMedicalAsync(AdminMedicalModel model, string id)
		{
			var medical = new Medical
			{
				Id = Guid.NewGuid(),
				HealthRecordId = Guid.Parse(id),
				HealthRecord = dbContext.HealthRecords.FirstOrDefault(x => x.Id.ToString() == id),
				DoctorId = Guid.Parse(model.DoctorId),
				Doctor = dbContext.Doctors.FirstOrDefault(x => x.Id.ToString() == model.DoctorId),
				Date = model.Date,
				Reason = model.Reason,
				Constatation = model.Constatation
			};

			await dbContext.Medicals.AddAsync(medical);
			await dbContext.SaveChangesAsync();
		}


	}

}
