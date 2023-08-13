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
                                      OwnerId = a.OwnerId,
                                      Owner = new AdminOwnerModel()
                                      { 
                                        FirstName = a.Owner.FirstName,
                                        MiddleName = a.Owner.MiddleName,
                                        LastName = a.Owner.LastName,
                                        Address = a.Owner.Address,
                                        PhoneNumber = a.Owner.PhoneNumber
                                      },
                                      HealthRecordId = a.HealthRecordId,
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
                                      GroomingId = a.GroomingId,
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

		public async Task<IEnumerable<IndexDoctorModel>> GetAllDoctors()
		{
			var doctors = await dbContext.Doctors
								.Select(d => new IndexDoctorModel()
								{
									FirstName = d.FirstName,
									LastName = d.LastName,
									ImageUrl = d.Photo,
									Specialization = d.Specialization,
                                    PhoneNumber = d.PhoneNumber
								})
								.ToListAsync();

			return doctors;
		}

		public async Task<IEnumerable<IndexTrainerModel>> GetAllTrainers()
		{
			var trainers = await dbContext.Trainers
									.Select(t => new IndexTrainerModel()
									{
										FirstName = t.FirstName,
										LastName = t.LastName,
										ImageUrl = t.Photo,
                                        PhoneNumber = t.PhoneNumber
									})
									.ToListAsync();

			return trainers;
		}

        public async Task<AdminAnimalModel> GetAnimalById(string animalId)
        {
            throw new NotImplementedException();
        }
    }
}
