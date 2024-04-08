using ForAnimalsWithLove.ViewModels.Admins;

namespace ForAnimalsWithLove.Data.Service.Model
{
	public class AllDoctorsFiltredServiceModel
	{
		public AllDoctorsFiltredServiceModel()
		{
			this.Doctors = new List<AdminDoctorModel>();
		}

		public int TotalDoctorsCount { get; set; }

		public IEnumerable<AdminDoctorModel> Doctors { get; set; }
	}
}
