using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HospitalRecord;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminHospitalModel
    {
        public AdminHospitalModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Operations = new HashSet<AdminOperationModel>();
        }

        public string Id { get; set; }

        [Required]
        public DateTime DateOfAcceptance { get; set; }

        [Required]
        public DateTime DateOfDischarge { get; set; }

        [Required]
        [StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
        public string Diagnosis { get; set; } = null!;

        [Required]
        [StringLength(TreatmentMaxLength, MinimumLength = TreatmentMinLength)]
        public string Treatment { get; set; } = null!;

        [StringLength(TreatmentMaxLength, MinimumLength = TreatmentMinLength)]
        public string? PrescribedTreatment { get; set; }

        public Guid HealthRecordId { get; set; }

        public AdminHealthModel HealthRecord { get; set; } = null!;

        public ICollection<AdminOperationModel> Operations { get; set; }
    }
}
