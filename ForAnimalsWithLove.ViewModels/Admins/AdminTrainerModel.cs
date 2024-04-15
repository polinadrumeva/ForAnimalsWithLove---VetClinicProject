using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.ViewModels.Admins
{
	public class AdminTrainerModel
	{
		public AdminTrainerModel()
		{
			this.Id = Guid.NewGuid().ToString();
			this.Educations = new HashSet<AdminEducationModel>();
		}

		public string Id { get; set; }

        [Required]
		[StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
		[Display(Name = "Име")]
		public string FirstName { get; set; } = null!;

		[Required]
		[StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
		[Display(Name = "Фамилия")]
		public string LastName { get; set; } = null!;

		[Required]
		[Display(Name = "Снимка")]
		public string Photo { get; set; } = null!;

		[Required]
		[StringLength(PhoneNumberLength)]
		[Display(Name = "Телефонен номер")]
		public string PhoneNumber { get; set; } = null!;

        public IEnumerable<AdminEducationModel> Educations { get; set; }
    }
}
