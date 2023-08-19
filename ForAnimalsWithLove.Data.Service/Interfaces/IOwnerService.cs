using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IOwnerService
    {
        Task<bool> OwnerExistByUserIdAsync(string userId);
    }
}
