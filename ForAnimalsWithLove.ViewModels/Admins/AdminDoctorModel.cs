using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminDoctorModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberLength)]
        [Display(Name = "Телефонен номер")]
        public string PhoneNumber { get; set; } = null!;

		[Display(Name = "Специалности/Специализации")]
		public string? Specialization { get; set; }


		[Required]
		[StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = "Адрес")]
		public string Address { get; set; } = null!;


	}
}
