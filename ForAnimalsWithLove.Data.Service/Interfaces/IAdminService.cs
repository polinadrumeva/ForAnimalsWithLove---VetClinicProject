using ForAnimalsWithLove.ViewModels.Admins;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminAnimalModel>> GetAllAnimals();
    }
}
