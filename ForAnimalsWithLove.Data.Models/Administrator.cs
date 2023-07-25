using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.Data.Models
{
    public class Administrator
    {
        public Administrator()
        {
            this.Id = Guid.NewGuid();
            this.HealthRecords = new HashSet<HealthRecord>();
            this.HospitalRecords = new HashSet<HospitalRecord>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(PhoneNumberLength)]
        public string PhoneNumber { get; set; }

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<HealthRecord> HealthRecords { get; set; }

        public virtual ICollection<HospitalRecord> HospitalRecords { get; set; }
    }
}
