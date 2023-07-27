using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Id = Guid.NewGuid();
            this.Operations = new HashSet<Operation>();
            this.DirectionsDoctors = new HashSet<DirectionDoctor>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        public string? Specialization { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        [StringLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

       
        public virtual ICollection<DirectionDoctor> DirectionsDoctors { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }

	}
}
