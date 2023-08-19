using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.ViewModels.Admins
{
	public class AdminBookingModel
	{
		public AdminBookingModel()
		{
			this.Id = Guid.NewGuid().ToString();
			this.Hotels = new HashSet<AdminHotelModel>();
		}

		public string Id { get; set; }

		public int HotelId { get; set; }

		public AdminHotelModel Hotel { get; set; } = null!;

		[Required]
		[Display(Name = "Начална дата")]
		public DateTime StartDate { get; set; }

		[Required]
		[Display(Name = "Крайна дата")]
		public DateTime EndDate { get; set; }

		[Required]
		[Display(Name = "Дни престой")]
		public int Days { get; set; }

		public virtual ICollection<AdminHotelModel> Hotels { get; set; }
    }
}
