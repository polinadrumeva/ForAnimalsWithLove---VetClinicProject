using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HospitalRecord;

namespace ForAnimalsWithLove.Data.Models
{
    public class Medical
    {
        public Medical()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public Doctor Doctor { get; set; } = null!;
        
        [Required]
        public Guid HealthRecordId { get; set; }

        [Required]
        public HealthRecord HealthRecord { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
        public string Reason { get; set; } = null!;

        [Required]
        [StringLength(DiagnosisMaxLength, MinimumLength = DiagnosisMinLength)]
        public string Constatation { get; set; } = null!;

        //[Required]
        //[Range(typeof(decimal), AmountMinValue, MaxPriceMedical)]
        //public decimal Price { get; set; }
    }
}
