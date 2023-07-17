using Microsoft.EntityFrameworkCore;

using ForAnimalsWithLove.Data.Service.Interfaces;
using ForAnimalsWithLove.ViewModels.Owners;

namespace ForAnimalsWithLove.Data.Service.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly ForAnimalsWithLoveDbContext dbContext;

        public OwnerService(ForAnimalsWithLoveDbContext dbContext)
        {
            this.dbContext = dbContext;
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

        //This should be in a different service for administrators
        public async Task<bool> OwnerExistByPhone(string phone)
        {
            var result = await dbContext.Owners.AnyAsync(o => o.PhoneNumber == phone);
            return result;
        }
    }
}
