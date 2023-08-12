using Microsoft.EntityFrameworkCore;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ForAnimalsWithLoveDbContext dbContext;

        public OwnerService(ForAnimalsWithLoveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Create(string userId, RegistrationOwnerViewModel model)
        {
            throw new NotImplementedException();
        }

        //public Task Create(string userId, RegistrationOwnerViewModel model)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> OwnerExistById(string userId)
        {
            var result = await dbContext.Owners.AnyAsync(o => o.Id.ToString() == userId);
            return result;
        }


        
    }
}
