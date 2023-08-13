using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Animal;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminAnimalModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(AgeMinValue, AgeMaxValue)]
        public int Age { get; set; }

        public string? Photo { get; set; }

        [Required]
        [StringLength(KindOfAnimalMaxLength, MinimumLength = KindOfAnimalMinLength)]
        public string KindOfAnimal { get; set; } = null!;

        [Required]
        [StringLength(BreedMaxLength, MinimumLength = BreedMinLength)]
        public string Breed { get; set; } = null!;

        [Required]
        public char Sex { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; } = null!;

        [Required]
        public bool DoesHasOwner { get; set; }

        public Guid? OwnerId { get; set; }

        public virtual AdminOwnerModel? Owner { get; set; }

        public Guid? GroomingId { get; set; }

        public virtual AdminGroomingModel? Grooming { get; set; }

        [Required]
        public Guid HealthRecordId { get; set; }

        [Required]
        public virtual AdminHealthModel HealthRecord { get; set; } = null!;

        public int? SearchHomeId { get; set; }
        public virtual AdminSearchHomeModel? SearchHome { get; set; }
    }
}
