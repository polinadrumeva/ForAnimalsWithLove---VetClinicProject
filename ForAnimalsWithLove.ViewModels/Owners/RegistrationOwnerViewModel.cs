using System.ComponentModel.DataAnnotations;
using static ForAnimalsWithLove.Common.Validations.EntityValidations.Owner;

namespace ForAnimalsWithLove.ViewModels.Owners
{
    public class RegistrationOwnerViewModel
    {
        public string FirstName { get; set; } = null!;

        [Required]
		[StringLength(PhoneNumberLength)]
		public string PhoneNumber { get; set; } = null!;
    }
}
