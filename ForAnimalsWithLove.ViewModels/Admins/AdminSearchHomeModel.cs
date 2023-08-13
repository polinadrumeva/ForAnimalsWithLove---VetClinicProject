using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminSearchHomeModel
    {
        [Required]
        public Guid AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public AdminAnimalModel Animal { get; set; } = null!;

        public string? Location { get; set; }

        public string? Habits { get; set; }
    }
}
