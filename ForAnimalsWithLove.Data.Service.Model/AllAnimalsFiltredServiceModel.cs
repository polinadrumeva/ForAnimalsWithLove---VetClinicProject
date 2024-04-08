using ForAnimalsWithLove.ViewModels.Admins;

namespace ForAnimalsWithLove.Data.Service.Model
{
	public class AllAnimalsFiltredServiceModel
	{
        public AllAnimalsFiltredServiceModel()
        {
            this.Animals = new List<AdminAnimalModel>();
        }

        public int TotalAnimalsCount { get; set; }

		public IEnumerable<AdminAnimalModel> Animals { get; set; }
    }
}