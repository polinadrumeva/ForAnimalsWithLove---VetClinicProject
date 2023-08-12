using System.ComponentModel.DataAnnotations;
using static ForAnimalsWithLove.Common.Validations.EntityValidations.Owner;

namespace ForAnimalsWithLove.ViewModels.IndexModels
{
    public class RegistrationOwnerViewModel
    {
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Въведете валиден телефонен номер")]
        [StringLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; } = null!;
    }
}
