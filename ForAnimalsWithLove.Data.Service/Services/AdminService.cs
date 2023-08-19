using ForAnimalsWithLove.Data.Models;
using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;
using Microsoft.EntityFrameworkCore;

namespace ForAnimalsWithLove.Data.Service.Services
{
	public class AdminService : IAdminService
	{

		private readonly ForAnimalsWithLoveDbContext dbContext;

		public AdminService(ForAnimalsWithLoveDbContext dbContext)
		{
			this.dbContext = dbContext;
		}


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

		public async Task EditAnimalAsync(AdminAnimalModel model)
		{
			var existAnimal = await dbContext.Animals.FirstOrDefaultAsync(x => x.Id.ToString() == model.Id);

			if (existAnimal != null)
			{
				existAnimal.Id = existAnimal.Id;
				existAnimal.Name = model.Name;
				existAnimal.Age = model.Age;
				existAnimal.Photo = model.Photo;
				existAnimal.KindOfAnimal = model.KindOfAnimal;
				existAnimal.Breed = model.Breed;
				existAnimal.Color = model.Color;
				existAnimal.Birthdate = model.Birthdate;
				existAnimal.Sex = Char.Parse(model.Sex);
				existAnimal.DoesHasOwner = model.DoesHasOwner;


				await dbContext.SaveChangesAsync();
			}
		}

		public async Task AddAnimalAsync(AdminAnimalModel model)
		{
			var animal = new Animal
			{
				Id = Guid.Parse(model.Id),
				Name = model.Name,
				Age = model.Age,
				Photo = model.Photo,
				KindOfAnimal = model.KindOfAnimal,
				Breed = model.Breed,
				Color = model.Color,
				Sex = Char.Parse(model.Sex),
				Birthdate = model.Birthdate,
				DoesHasOwner = model.DoesHasOwner
			};

			await dbContext.Animals.AddAsync(animal);
			await dbContext.SaveChangesAsync();
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
		public async Task<AdminGroomingModel> GetGroomingModelAsync()
		{
			var model = new AdminGroomingModel();

			return model;
		}

		public async Task AddGroomingAsync(AdminGroomingModel model, string id)
		{
			var grooming = new Grooming
			{
				Id = Guid.NewGuid(),
				AnimalId = Guid.Parse(id),
				Service = model.Service

			};

			var animal = await dbContext.Animals.FirstOrDefaultAsync(x => x.Id.ToString() == id);
			animal.GroomingId = grooming.Id;

			await dbContext.Groomings.AddAsync(grooming);
			await dbContext.SaveChangesAsync();
		}
		public async Task<AdminEducationModel> GetEducationModelAsync()
		{
			var trainers = await dbContext.Trainers
				.Select(x => new AdminTrainerModel
				{
					Id = x.Id.ToString(),
					FirstName = x.FirstName,
					LastName = x.LastName
				})
				.ToListAsync();

			var model = new AdminEducationModel
			{
				AdminTrainers = trainers
			};

			return model;
		}

		public async Task AddEducationAsync(AdminEducationModel model, string id)
		{
			var education = new Models.Education
			{
				Id = Guid.NewGuid(),
				TrainerId = Guid.Parse(model.TrainerId),
				Trainer = dbContext.Trainers.FirstOrDefault(x => x.Id.ToString() == model.TrainerId),
				Days = model.Days

			};

			var animalEducation = new AnimalEducation
			{ 
				AnimalId = Guid.Parse(id),
				EducationId = education.Id,
				Animal = dbContext.Animals.FirstOrDefault(x => x.Id.ToString() == id),
				Education = education
				
			};
			

			await dbContext.Educations.AddAsync(education);
			await dbContext.AnimalsEducations.AddAsync(animalEducation);
			await dbContext.SaveChangesAsync();
		}

		public async Task<AdminBookingModel> GetBookingModelAsync()
		{
			var hotels = await dbContext.Hotels
				.Select(x => new AdminHotelModel
				{
					Id = x.Id,
					Name = x.Name
				})
				.ToListAsync();

			var model = new AdminBookingModel
			{
				Hotels = hotels
			};

			return model;
		}

		public async Task AddBookingAsync(AdminBookingModel model, string id)
		{
			var booking = new Booking
			{
				Id = Guid.NewGuid(),
				HotelId = model.HotelId,
				Hotel = dbContext.Hotels.FirstOrDefault(x => x.Id == model.HotelId),
				StartDate = model.StartDate,
				EndDate = model.EndDate,
				Days = model.Days


			};

			var animalBooking = new AnimalBooking
			{
				AnimalId = Guid.Parse(id),
				BookingId = booking.Id,
				Animal = dbContext.Animals.FirstOrDefault(x => x.Id.ToString() == id),
				Booking = booking

			};
			
			await dbContext.Bookings.AddAsync(booking);
			await dbContext.AnimalsBookings.AddAsync(animalBooking);
			await dbContext.SaveChangesAsync();
		}

		public async Task<AdminSearchHomeModel> GetSearchHomeModelAsync()
		{
			var model = new AdminSearchHomeModel();

			return model;
		}

		public async Task AddSearchHomeAsync(AdminSearchHomeModel model, string id)
		{
			var searchHome = new SearchHome
			{
				AnimalId = Guid.Parse(id),
				Animal = dbContext.Animals.FirstOrDefault(x => x.Id.ToString() == id),
				Location = model.Location,
				Habits = model.Habits

			};

			var animal = await dbContext.Animals.FirstOrDefaultAsync(x => x.Id.ToString() == id);
			animal.SearchHomeId = searchHome.Id;

			await dbContext.SearchHomes.AddAsync(searchHome);
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

		public async Task<AdminOwnerModel> GetOwnerModelAsync()
		{
			var model = new AdminOwnerModel();

			return model;
		}

		public async Task AddOwnerAsync(AdminOwnerModel model, string id)
		{
			var owner = new Owner
			{
				Id = Guid.NewGuid(),
				FirstName = model.FirstName,
				MiddleName = model.MiddleName,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber,
				Address = model.Address
		
			};

			owner.MyAnimals.Add(dbContext.Animals.FirstOrDefault(x => x.Id.ToString() == id));

			var animal = await dbContext.Animals.FirstOrDefaultAsync(x => x.Id.ToString() == id);
			animal.OwnerId = owner.Id;
			animal.Owner = owner;
			animal.SearchHomeId = null;

			await dbContext.Owners.AddAsync(owner);
			await dbContext.SaveChangesAsync();
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


		// Doctors services
		public async Task<IEnumerable<IndexDoctorModel>> GetAllDoctors()
		{
			var doctors = await dbContext.Doctors
								.Select(d => new IndexDoctorModel()
								{
									Id = d.Id.ToString(),
									FirstName = d.FirstName,
									LastName = d.LastName,
									ImageUrl = d.Photo,
									Specialization = d.Specialization,
									PhoneNumber = d.PhoneNumber
								})
								.ToListAsync();

			return doctors;
		}

		public async Task<AdminDoctorModel> GetDoctorModelAsync()
		{
			var directories = await dbContext.Directions
				.Select(x => new AdminDirectoryModel
				{
					Id = x.Id,
					Name = x.Name
				})
				.ToListAsync();

			var model = new AdminDoctorModel
			{
				Directories = directories
			};

			return model;
		}

		public async Task AddDoctorAsync(AdminDoctorModel model)
		{
			var doc = new Doctor
			{
				Id = Guid.Parse(model.Id),
				FirstName = model.FirstName,
				LastName = model.LastName,
				Specialization = model.Specialization,
				Address = model.Address,
				PhoneNumber = model.PhoneNumber,
				Photo = model.Photo
			};

			await dbContext.Doctors.AddAsync(doc);
			await dbContext.SaveChangesAsync();
		}
		public async Task<AdminDoctorModel?> GetDoctorByIdAsync(string id)
		{
			return await dbContext.Doctors.Where(x => x.Id.ToString() == id)
				.Select(x => new AdminDoctorModel
				{
					FirstName = x.FirstName,
					LastName = x.LastName,
					Specialization = x.Specialization,
					Address = x.Address,
					PhoneNumber = x.PhoneNumber,
					Photo = x.Photo,
					Directories = dbContext.Directions.Select(c => new AdminDirectoryModel
					{
						Id = c.Id,
						Name = c.Name
					}).ToList()

				}).FirstOrDefaultAsync();
		}

		public async Task EditDoctorAsync(AdminDoctorModel model)
		{
			var existDoctor = await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id.ToString() == model.Id);

			if (existDoctor != null)
			{

				existDoctor.FirstName = model.FirstName;
				existDoctor.LastName = model.LastName;
				existDoctor.PhoneNumber = model.PhoneNumber;
				existDoctor.Address = model.Address;
				existDoctor.Photo = model.Photo;
				existDoctor.Specialization = model.Specialization;

				await dbContext.SaveChangesAsync();
			}
		}
		public async Task<AdminDoctorModel> GetDoctorDetailsAsync(string doctorId)
		{
			var doctor = await dbContext.Doctors
									.FirstAsync(d => d.Id.ToString() == doctorId);

			return new AdminDoctorModel()
			{
				Id = doctor.Id.ToString(),
				FirstName = doctor.FirstName,
				LastName = doctor.LastName,
				Specialization = doctor.Specialization,
				Address = doctor.Address,
				PhoneNumber = doctor.PhoneNumber,
				Photo = doctor.Photo
			};
		}
		public async Task RemoveDoctorAsync(AdminDoctorModel model, string id)
		{
			var doctor = await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id.ToString() == id);

			if (doctor != null)
			{
				dbContext.Doctors.Remove(doctor);
				await dbContext.SaveChangesAsync();
			}
		}

		// Trainers services
		public async Task<IEnumerable<IndexTrainerModel>> GetAllTrainers()
		{
			var trainers = await dbContext.Trainers
									.Select(t => new IndexTrainerModel()
									{
										Id = t.Id.ToString(),
										FirstName = t.FirstName,
										LastName = t.LastName,
										ImageUrl = t.Photo,
										PhoneNumber = t.PhoneNumber
									})
									.ToListAsync();

			return trainers;
		}



		public async Task<AdminTrainerModel> GetTrainerModelAsync()
		{
			var model = new AdminTrainerModel();

			return model;
		}

		public async Task AddTrainerAsync(AdminTrainerModel model)
		{
			var trainer = new Trainer
			{
				Id = Guid.Parse(model.Id),
				FirstName = model.FirstName,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber,
				Photo = model.Photo
			};

			await dbContext.AddAsync(trainer);
			await dbContext.SaveChangesAsync();
		}

		public async Task<AdminTrainerModel?> GetTrainerByIdAsync(string id)
		{
			return await dbContext.Trainers.Where(x => x.Id.ToString() == id)
				.Select(x => new AdminTrainerModel
				{
					Id = x.Id.ToString(),
					FirstName = x.FirstName,
					LastName = x.LastName,
					PhoneNumber = x.PhoneNumber,
					Photo = x.Photo

				}).FirstOrDefaultAsync();
		}

		public async Task EditTrainerAsync(AdminTrainerModel model)
		{
			var existTrainer = await dbContext.Trainers.FirstOrDefaultAsync(x => x.Id.ToString() == model.Id);

			if (existTrainer != null)
			{

				existTrainer.FirstName = model.FirstName;
				existTrainer.LastName = model.LastName;
				existTrainer.PhoneNumber = model.PhoneNumber;
				existTrainer.Photo = model.Photo;

				await dbContext.SaveChangesAsync();
			}
		}

		public async Task RemoveTrainerAsync(AdminTrainerModel model, string id)
		{
			var trainer = await dbContext.Trainers.FirstOrDefaultAsync(x => x.Id.ToString() == id);

			if (trainer != null)
			{
				dbContext.Trainers.Remove(trainer);
				await dbContext.SaveChangesAsync();
			}
		}

        public async Task<bool> AdminExistByUserIdAsync(string userId)
        {
            var result = await dbContext.Administrators.AnyAsync(x => x.UserId.ToString() == userId);

			return result;
        }
    }
}
