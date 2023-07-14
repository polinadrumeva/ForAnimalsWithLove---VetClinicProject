using ForAnimalsWithLove.ViewModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IHomeService
    {
        Task<IEnumerable<IndexViewModel>> GetAnimals();
    }
}
