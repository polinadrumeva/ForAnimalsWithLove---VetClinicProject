using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Operations = new HashSet<Operation>();
            this.AnimalsDoctors = new HashSet<AnimalDoctor>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(DirectionMaxLength, MinimumLength = DirectionMinLength)]
        public string Direction { get; set; } = null!;

        public string? Specialization { get; set; }

        [Required]
        [StringLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        public virtual ICollection<AnimalDoctor> AnimalsDoctors { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }

	}
}
