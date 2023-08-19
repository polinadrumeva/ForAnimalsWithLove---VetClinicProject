using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static ForAnimalsWithLove.Common.Validations.EntityValidations.User;

namespace ForAnimalsWithLove.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

		[Required]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; } = null!;
    }
}
