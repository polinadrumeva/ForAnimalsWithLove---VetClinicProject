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
    public class TrainerService : ITrainerService
    {
        private readonly ForAnimalsWithLoveDbContext dbContext;

        public TrainerService(ForAnimalsWithLoveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<bool> TrainerExistByUserIdAsync(string userId)
        {
            var result = await dbContext.Trainers.AnyAsync(x => x.UserId.ToString() == userId);

            return result;
        }

        public async Task<IndexTrainerModel> GetTrainerExistByUserIdAsync(string id)
        {
            var trainer = await dbContext.Trainers.FirstOrDefaultAsync(o => o.UserId.ToString() == id);

            if (trainer != null)
            {
                return new IndexTrainerModel
                {
                    Id = trainer.Id.ToString(),
                    FirstName = trainer.FirstName
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
	}
}
