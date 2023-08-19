using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminSearchHomeModel
    {
        

        public int Id { get; set; }
        public string AnimalId { get; set; } = null!;

        [ForeignKey(nameof(AnimalId))]
        public AdminAnimalModel Animal { get; set; } = null!;

        [Display(Name = "Локация")]
        public string? Location { get; set; }

		[Display(Name = "Навици")]
		public string? Habits { get; set; }
    }
}
