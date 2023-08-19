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



        public async Task<bool> OwnerExistByUserIdAsync(string userId)
        {
            var result = await dbContext.Owners.AnyAsync(o => o.UserId.ToString() == userId);
            return result;
        }
    }
}
