using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminDoctorModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;

        
    }
}
