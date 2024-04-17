using ForAnimalsWithLove.Data.Models;
using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.Data.Service.Model;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Animals;
using ForAnimalsWithLove.ViewModels.Enums;
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

		public async Task<AllAnimalsFiltredServiceModel> AllAnimalsAsync(AllAnimalsQueryModel queryModel)
		{
			var animalsQuery = dbContext.Animals.AsQueryable();
			var wildCard = $"%{queryModel.SearchString?.ToLower()}%";

			if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
			{
				animalsQuery = animalsQuery.Where(a => EF.Functions.Like(a.Name, wildCard) ||
													   EF.Functions.Like(a.Owner.FirstName, wildCard) ||
													   EF.Functions.Like(a.Owner.LastName, wildCard));
			}

			animalsQuery = queryModel.AnimalSorting switch
			{
				AnimalSorting.Name => animalsQuery.OrderBy(a => a.Name),
				AnimalSorting.Age => animalsQuery.OrderBy(a => a.Age),
				AnimalSorting.KindOfAnimal => animalsQuery.OrderBy(a => a.KindOfAnimal),
				_ => animalsQuery.OrderBy(a => a.Name)
			};

			var allAnimals = await animalsQuery.Skip((queryModel.CurrentPage - 1) * queryModel.AnimalsPerPage)
				.Take(queryModel.AnimalsPerPage)
				.Select(a => new AdminAnimalModel()
				{
					Id = a.Id.ToString(),
					Name = a.Name,
					Age = a.Age,
					Photo = a.Photo,
					KindOfAnimal = a.KindOfAnimal,
					Breed = a.Breed,
					OwnerName = a.Owner.FirstName + " " + a.Owner.LastName
				}).ToArrayAsync();

			var totalAnimals = animalsQuery.Count();

			return new AllAnimalsFiltredServiceModel
			{
				TotalAnimalsCount = totalAnimals,
				Animals = allAnimals
			};
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

		public async Task<AdminHealthModel> GetHealthRecordByIdAsync(string healthId)
		{
			return await dbContext.HealthRecords.Where(x => x.Id.ToString() == healthId)
				.Select(x => new AdminHealthModel
				{
					Microchip = x.Microchip,
					MicrochipNumber = x.MicrochipNumber,
					FirstVaccine = x.FirstVaccine,
					SecondVaccine = x.SecondVaccine,
					ThirdVaccine = x.ThirdVaccine,
					AnnualVaccine = x.AnnualVaccine,
					GeneralCondition = x.GeneralCondition

				}).FirstOrDefaultAsync();
		}

		public async Task EditHealthRecordAsync(AdminHealthModel model)
		{
			var existRecord = await dbContext.HealthRecords.FirstOrDefaultAsync(x => x.Id.ToString() == model.Id);

			if (existRecord != null)
			{
				existRecord.Microchip = model.Microchip;
				existRecord.MicrochipNumber = model.MicrochipNumber;
				existRecord.FirstVaccine = model.FirstVaccine;
				existRecord.SecondVaccine = model.SecondVaccine;
				existRecord.ThirdVaccine = model.ThirdVaccine;
				existRecord.AnnualVaccine = model.AnnualVaccine;
				existRecord.GeneralCondition = model.GeneralCondition;
				

				await dbContext.SaveChangesAsync();
			}
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
				GeneralCondition = model.GeneralCondition

			};

			var animal = await dbContext.Animals.FirstOrDefaultAsync(x => x.Id.ToString() == id);
			animal.HealthRecordId = healthRecord.Id;

			await dbContext.HealthRecords.AddAsync(healthRecord);
			await dbContext.SaveChangesAsync();
		}

		public async Task<AdminAnimalModel> GetAnimalDetailsAsync(string id)
		{
			var animal = await dbContext.Animals.FirstAsync(x => x.Id.ToString() == id);
			var owner = await dbContext.Owners.FirstOrDefaultAsync(x => x.Id == animal.OwnerId);

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
				Birthdate = animal.Birthdate,
				DoesHasOwner = animal.DoesHasOwner,
				OwnerId = animal.OwnerId.ToString(),
				Owner = new AdminOwnerModel
				{
					FirstName = owner.FirstName,
					LastName = owner.LastName,
					PhoneNumber = owner.PhoneNumber,
					Address = owner.Address
				}
			};

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
			healthRecord.HospitalsRecords.Add(hospitalRecord);

			await dbContext.HospitalRecords.AddAsync(hospitalRecord);
			await dbContext.SaveChangesAsync();
			
			

		}

		public async Task<AnimalMedicalModel> GetMedicalModelAsync()
		{
			var doctors = await dbContext.Doctors
				.Select(x => new AdminDoctorModel
				{
					Id = x.Id.ToString(),
					FirstName = x.FirstName,
					LastName = x.LastName
				})
				.ToListAsync();

			var model = new AnimalMedicalModel
			{
				Doctors = doctors
			};

			return model;
		}

		public async Task AddMedicalAsync(AnimalMedicalModel model, string id)
		{
			var animal = await dbContext.Animals.Include(a => a.HealthRecord).FirstOrDefaultAsync(a => a.HealthRecordId.ToString() == id);

			var medical = new Medical
			{
				Id = Guid.NewGuid(),
				HealthRecordId = Guid.Parse(id),
				HealthRecord = dbContext.HealthRecords.FirstOrDefault(x => x.Id.ToString() == id),
				DoctorId = Guid.Parse(model.DoctorId),
				Doctor = dbContext.Doctors.FirstOrDefault(x => x.Id.ToString() == model.DoctorId),
				Date = model.Date,
				Reason = model.Reason,
				Constatation = model.Constatation,
				PrescribedTreatment = model.PrescribedTreatment
			};

			await dbContext.Medicals.AddAsync(medical);
			await dbContext.SaveChangesAsync();
		}

		
	}

}
