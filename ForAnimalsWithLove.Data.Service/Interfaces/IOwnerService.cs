using ForAnimalsWithLove.ViewModels.Owners;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IOwnerService
    {
        Task<bool> OwnerExistById(string userId);

        Task<bool> OwnerExistByPhone(string phone);

        Task Create(string userId, RegistrationOwnerViewModel model);
    }
}
