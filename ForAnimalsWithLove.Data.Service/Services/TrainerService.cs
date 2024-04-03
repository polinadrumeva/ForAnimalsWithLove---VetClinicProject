using ForAnimalsWithLove.Data.Models;
using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.IndexModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
