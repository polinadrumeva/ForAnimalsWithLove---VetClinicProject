using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HospitalRecord;

namespace ForAnimalsWithLove.Data.Models
{
    public class HospitalRecord
    {
        public HospitalRecord()
        {
            this.Operations = new HashSet<Operation>();
        }

        [Key]
        public int Id { get; set; }

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

        [Required]
        public decimal Amount { get; set; }

        public ICollection<Operation> Operations { get; set; } 
    }

}
