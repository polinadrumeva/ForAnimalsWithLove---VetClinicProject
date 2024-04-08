
using ForAnimalsWithLove.Common;
using ForAnimalsWithLove.ViewModels.Admins;
using ForAnimalsWithLove.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.ViewModels.Animals
{
	public class AllAnimalsQueryModel
	{
        public AllAnimalsQueryModel()
        {
            this.CurrentPage = GeneralAppConstants.DefaultPage;
            this.AnimalsPerPage = GeneralAppConstants.AnimalsPerPage;
            this.Animals = new List<AdminAnimalModel>();
        }

        [Display(Name = "Търси по име")]
        public string? SearchString { get; set; }

		[Display(Name = "Сортирай по")]
        public AnimalSorting AnimalSorting { get; set; }

        public int CurrentPage { get; set; }

        public int AnimalsPerPage { get; set; }

        public int TotalAnimals { get; set; }

        public IEnumerable<AdminAnimalModel> Animals { get; set; }
    }
}
