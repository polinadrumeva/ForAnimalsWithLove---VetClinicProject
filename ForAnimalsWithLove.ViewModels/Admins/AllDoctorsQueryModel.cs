using ForAnimalsWithLove.Common;
using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.ViewModels.Admins
{
	public class AllDoctorsQueryModel
	{
		public AllDoctorsQueryModel()
		{
			this.CurrentPage = GeneralAppConstants.DefaultPage;
			this.DoctorsPerPage = GeneralAppConstants.AnimalsPerPage;
			this.Directions = new HashSet<string>();
			this.Doctors = new List<AdminDoctorModel>();
		}

		[Display(Name = "Направление")]
		public string? Direction { get; set; }

        [Display(Name = "Търси по име")]
		public string? SearchString { get; set; }

		public int CurrentPage { get; set; }

		public int DoctorsPerPage { get; set; }

		public int TotalDoctors { get; set; }

		public IEnumerable<string> Directions { get; set; } 

		public IEnumerable<AdminDoctorModel> Doctors { get; set; }
	}
}

