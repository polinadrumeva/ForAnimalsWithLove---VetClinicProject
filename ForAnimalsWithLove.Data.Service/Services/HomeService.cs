using Microsoft.EntityFrameworkCore;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Services
{
    public class HomeService : IHomeService
    {
        private readonly ForAnimalsWithLoveDbContext dbContext;

        public HomeService(ForAnimalsWithLoveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<IndexModel>> GetAllAnimalsAsync()
        {
            var animals = await dbContext.Animals
                                .Select(a => new IndexModel()
                                {
                                    Name = a.Name
                                })
                                .ToListAsync();

            return animals;
        }

        public async Task<IndexCountsModel> GetAllCount()
        {
            var countModel = new IndexCountsModel()
            {
                AnimalsCount = await dbContext.Animals.CountAsync(),
                DoctorCount = await dbContext.Doctors.CountAsync(),
                ForAdoptionCount = await dbContext.SearchHomes.CountAsync()
            };

            return countModel;
        }

        public async Task<IEnumerable<IndexDoctorModel>> GetAllDoctors()
        {
            var doctors = await dbContext.Doctors
                                .Select(d => new IndexDoctorModel()
                                {
                                    FirstName = d.FirstName,
                                    LastName = d.LastName,
                                    ImageUrl = d.Photo,
                                    Specialization = d.Specialization
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
                                        ImageUrl = t.Photo
                                    })
                                    .ToListAsync();

            return trainers;
        }

        public async Task<IEnumerable<IndexSearchHomeModel>> GetAllForAdoption()
        {
            var animals = await dbContext.Animals
                                          .Where(a => a.SearchHome != null)
                                          .Select(a => new IndexSearchHomeModel()
                                          {
                                              Name = a.Name,
                                              Age = a.Age,
                                              Photo = a.Photo,
                                              Habits = a.SearchHome.Habits
                                          })
                                          .ToListAsync();

            return animals;
        }



		public async Task<RegistrationOwnerViewModel> OwnerExistByPhone(string phone)
		{
			var result = await dbContext.Owners
                                        .Where(o => o.PhoneNumber == phone)
                                        .Select(o => new RegistrationOwnerViewModel()
                                        { 
                                            PhoneNumber = o.PhoneNumber,
                                            FirstName = o.FirstName
                                        }).FirstOrDefaultAsync();
                                        
			return result;
		}
	}
}
