using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IOwnerService
    {
        Task<bool> OwnerExistById(string userId);

        Task Create(string userId, RegistrationOwnerViewModel model);
    }
}
