﻿using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HospitalRecordValidtions;

namespace ForAnimalsWithLove.Data.Models
{
    public class HospitalRecord
    {
        public HospitalRecord()
        {
            this.Id = Guid.NewGuid();
            this.Operations = new HashSet<Operation>();
            this.Tests = new HashSet<Test>();
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

        public virtual ICollection<Operation> Operations { get; set; } 

        public virtual ICollection<Test> Tests { get; set; }    
    }

}
