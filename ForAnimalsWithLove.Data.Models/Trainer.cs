using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.Data.Models
{
    public class Trainer
    {
        public Trainer()
        {
            this.Id = Guid.NewGuid();
            this.Educations = new HashSet<Education>();
        }


        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        
        public virtual ICollection<Education> Educations { get; set; }

    }


}
