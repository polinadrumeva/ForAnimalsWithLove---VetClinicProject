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
                                      Name = a.Name,
                                      Age = a.Age,
                                      Photo = a.Photo,
                                      KindOfAnimal = a.KindOfAnimal,
                                      Breed = a.Breed,
                                      Color = a.Color,
                                      Birthdate = a.Birthdate,
                                      Sex = a.Sex,
                                      DoesHasOwner = a.DoesHasOwner,
                                      OwnerId = a.OwnerId.ToString(),
                                      Owner = new AdminOwnerModel()
                                      { 
                                        FirstName = a.Owner.FirstName,
                                        MiddleName = a.Owner.MiddleName,
                                        LastName = a.Owner.LastName,
                                        Address = a.Owner.Address,
                                        PhoneNumber = a.Owner.PhoneNumber
                                      },
                                      HealthRecordId = a.HealthRecordId.ToString(),
                                      HealthRecord = new AdminHealthModel()
                                      { 
                                        MicrochipNumber = a.HealthRecord.MicrochipNumber,
                                        Microchip = a.HealthRecord.Microchip,
                                        FirstVaccine = a.HealthRecord.FirstVaccine,
                                        SecondVaccine = a.HealthRecord.SecondVaccine,
                                        ThirdVaccine = a.HealthRecord.ThirdVaccine,
                                        AnnualVaccine = a.HealthRecord.AnnualVaccine,
                                        GeneralCondition = a.HealthRecord.GeneralCondition,
                                        PrescribedTreatment = a.HealthRecord.PrescribedTreatment,
                                        HospitalRecordId = a.HealthRecord.HospitalRecordId
                                      },
                                      GroomingId = a.GroomingId.ToString(),
                                      Grooming = new AdminGroomingModel()
                                      {
                                        Service = a.Grooming.Service
                                      },
                                      SearchHomeId = a.SearchHomeId,
                                      SearchHome = new AdminSearchHomeModel()
                                      { 
                                        Location = a.SearchHome.Location,
                                        Habits = a.SearchHome.Habits
                                      }

                                  }).ToListAsync();

            return result;
        }

        public async Task<AdminAnimalModel> GetAnimalById(string animalId)
        {
            throw new NotImplementedException();
        }
		public async Task<AdminAnimalModel> GetAnimalModelAsync()
		{
			var model = new AdminAnimalModel();

			return model;
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
				Sex = model.Sex,
				Birthdate = model.Birthdate,
				DoesHasOwner = model.DoesHasOwner,
				Owner = new Owner
				{
					Id = Guid.Parse(model.OwnerId),
					FirstName = model.Owner.FirstName,
					MiddleName = model.Owner.MiddleName,
					LastName = model.Owner.LastName,
					Address = model.Owner.Address,
					PhoneNumber = model.Owner.PhoneNumber
				},
				HealthRecord = new HealthRecord
				{
					Id = Guid.Parse(model.HealthRecordId),
					MicrochipNumber = model.HealthRecord.MicrochipNumber,
					Microchip = model.HealthRecord.Microchip,
					FirstVaccine = model.HealthRecord.FirstVaccine,
					SecondVaccine = model.HealthRecord.SecondVaccine,
					ThirdVaccine = model.HealthRecord.ThirdVaccine,
					AnnualVaccine = model.HealthRecord.AnnualVaccine,
					GeneralCondition = model.HealthRecord.GeneralCondition,
					PrescribedTreatment = model.HealthRecord.PrescribedTreatment
				},
				Grooming = new Grooming
				{
					Id = Guid.Parse(model.GroomingId),
					Service = model.Grooming.Service
				},
				SearchHome = new SearchHome
				{
					Location = model.SearchHome.Location,
					Habits = model.SearchHome.Habits
				}
			};

			await dbContext.Animals.AddAsync(animal);
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

            await dbContext.AddAsync(doc);
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

	
	}
}
