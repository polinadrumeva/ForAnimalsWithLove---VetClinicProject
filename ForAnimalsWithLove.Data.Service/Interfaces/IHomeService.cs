using ForAnimalsWithLove.ViewModels.IndexModels;

namespace ForAnimalsWithLove.Data.Service.Interfaces
{
    public interface IHomeService
    {
        //Task<IEnumerable<IndexModel>> GetAnimals();

        Task<IEnumerable<IndexModel>> GetAllAnimalsAsync();

        Task<IEnumerable<IndexSearchHomeModel>> GetAllForAdoption();

        Task<IEnumerable<IndexDoctorModel>> GetAllDoctors();
		Task<IEnumerable<IndexTrainerModel>> GetAllTrainers();

		Task<IndexCountsModel> GetAllCount();
    }
}
