using Microsoft.EntityFrameworkCore;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels;

namespace ForAnimalsWithLove.Data.Service.Services
{
    public class HomeService : IHomeService
    {
        private readonly ForAnimalsWithLoveDbContext dbContext;

        public HomeService(ForAnimalsWithLoveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> GetAnimals()
        {
            var animals = await dbContext.Animals
                                          .Select(a => new IndexViewModel()
                                          {
                                              ImageUrl = a.Photo
                                          })
                                          .Take(10)
                                          .ToArrayAsync();

            return animals;
        }
    }
}
