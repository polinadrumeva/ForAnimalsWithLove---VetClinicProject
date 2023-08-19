using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Hotel;

namespace ForAnimalsWithLove.ViewModels.Admins
{
	public class AdminHotelModel
	{
		
		public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;

		[Required]
		[StringLength(LocationMaxLength, MinimumLength = LocationMinLength)]
		public string Location { get; set; } = null!;

	}
}
