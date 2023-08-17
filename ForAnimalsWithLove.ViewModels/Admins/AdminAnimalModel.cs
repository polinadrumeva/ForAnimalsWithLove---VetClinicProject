using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Animal;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminAnimalModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Име")]
        public string Name { get; set; } = null!;

        [Required]
        [Range(AgeMinValue, AgeMaxValue)]
        [Display(Name = "Възраст")]
        public int Age { get; set; }

        [Display(Name = "Снимка")]
        public string? Photo { get; set; }

        [Required]
        [StringLength(KindOfAnimalMaxLength, MinimumLength = KindOfAnimalMinLength)]
        [Display(Name = "Вид животно")]
        public string KindOfAnimal { get; set; } = null!;

        [Required]
        [StringLength(BreedMaxLength, MinimumLength = BreedMinLength)]
        [Display(Name = "Порода")]
        public string Breed { get; set; } = null!;

        [Required]
        [StringLength(SexMaxLength, MinimumLength = SexMinLength)]
        [Display(Name = "Пол")]
        public char Sex { get; set; }

        [Display(Name = "Родено")]
        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        [Display(Name = "Цвят")]
        public string Color { get; set; } = null!;

        [Required]
        [Display(Name = "Има ли собственик")]
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
