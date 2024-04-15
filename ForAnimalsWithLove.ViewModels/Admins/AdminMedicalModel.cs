using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HospitalRecordValidtions;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminMedicalModel
    {
        public AdminMedicalModel()
        {
            this.Doctors = new HashSet<AdminDoctorModel>();
        }

        public string DoctorId { get; set; } = null!;

        [Required]
        public AdminDoctorModel Doctor { get; set; } = null!;

        [Required]
        public Guid HealthRecordId { get; set; }

        [Required]
        public AdminHealthModel HealthRecord { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
        [Display(Name = "Причина")]
        public string Reason { get; set; } = null!;

        [Required]
        [StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
        [Display(Name = "Констатация")]
        public string Constatation { get; set; } = null!;

        public virtual ICollection<AdminDoctorModel> Doctors { get; set; }
    }
}
