using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HospitalRecord;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminMedicalModel
    { 
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
        public string Reason { get; set; } = null!;

        [Required]
        [StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
        public string Constatation { get; set; } = null!;
    }
}
