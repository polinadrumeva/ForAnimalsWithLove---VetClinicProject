using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.ViewModels.Admins
{
	public class AdminEducationModel
	{
        public AdminEducationModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.AdminTrainers = new HashSet<AdminTrainerModel>();
        }

        public string Id { get; set; }

        public string TrainerId { get; set; }

        [Required]
		public int Days { get; set; }

        [Required]
        public virtual ICollection<AdminTrainerModel> AdminTrainers { get; set; }
    }
}
