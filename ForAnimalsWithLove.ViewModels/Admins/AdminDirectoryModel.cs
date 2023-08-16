using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.ViewModels.Admins
{
	public class AdminDirectoryModel
	{
		public int Id { get; set; }

		[Required]
		[StringLength(DirectionMaxLength, MinimumLength = DirectionMinLength)]
		public string Name { get; set; } = null!;
	}
}
