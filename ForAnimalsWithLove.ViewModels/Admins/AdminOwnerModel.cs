using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Owner;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminOwnerModel
    {
        public AdminOwnerModel()
        {
            this.OwnerId = Guid.NewGuid().ToString();
        }

        public string OwnerId { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "Име")]
        public string FirstName { get; set; } = null!;

		[Display(Name = "Презиме")]
		public string? MiddleName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
		[Display(Name = "Фамилия")]
		public string LastName { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberLength)]
		[Display(Name = "Телефонен номер")]
		public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
		[Display(Name = "Адрес")]
		public string Address { get; set; } = null!;
    }
}
