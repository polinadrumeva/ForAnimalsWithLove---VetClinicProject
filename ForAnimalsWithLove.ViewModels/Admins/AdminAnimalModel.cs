using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Animal;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminAnimalModel
    {
        public AdminAnimalModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

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
        public string Sex { get; set; } = null!;

        [Display(Name = "Родено")]
        public DateTime Birthdate { get; set; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        [Display(Name = "Цвят")]
        public string Color { get; set; } = null!;

        [Required]
        [Display(Name = "Има ли собственик")]
        public bool DoesHasOwner { get; set; }

        public string? OwnerId { get; set; }

        public virtual AdminOwnerModel? Owner { get; set; }

        public string? OwnerName { get; set; }

        public string? OwnerPhoneNumber { get; set; }

        public string? GroomingId { get; set; }

        public virtual AdminGroomingModel? Grooming { get; set; }

        public string? HealthRecordId { get; set; } = null!;

        public virtual AdminHealthModel? HealthRecord { get; set; }

        public int? SearchHomeId { get; set; }
        public virtual AdminSearchHomeModel? SearchHome { get; set; }
    }
}
