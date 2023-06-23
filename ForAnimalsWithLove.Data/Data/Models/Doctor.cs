using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.Data.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Animals = new HashSet<Animal>();
            Operations = new HashSet<Operation>();
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

        public virtual ICollection<Animal> Animals { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
