using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HospitalRecord;

namespace ForAnimalsWithLove.Data.Models
{
    public class HospitalRecord
    {
        public HospitalRecord()
        {
            this.Id = Guid.NewGuid();
            this.Operations = new HashSet<Operation>();
        }

        [Key]
        public Guid Id { get; set; }

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

        public HealthRecord HealthRecord { get; set; } = null!;

        public ICollection<Operation> Operations { get; set; } 
    }

}
