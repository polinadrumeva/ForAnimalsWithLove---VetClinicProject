﻿using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HealthRecord;

namespace ForAnimalsWithLove.Data.Models
{
    public class HealthRecord
    {
        public HealthRecord()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
       
        public Guid AnimalId { get; set; }

        public Animal Animal { get; set; } = null!;

        [Required]
        public bool Microchip { get; set; }

        [StringLength(ChipMaxLength, MinimumLength = ChipMinLength)]
        public string? MicrochipNumber { get; set; }


        public bool FirstVaccine { get; set; }

        public bool SecondVaccine { get; set; }

        public bool ThirdVaccine { get; set; }

        [Required]
        public bool AnnualVaccine { get; set; }

        [Required]
        [StringLength(GeneralConditionMaxLength, MinimumLength = GeneralConditionMinLength)]
        public string GeneralCondition { get; set; } = null!;


        [StringLength(PrescriptionMaxLength, MinimumLength = PrescriptionMinLength)]
        public string? PrescribedTreatment { get; set; }

        public DateTime LastReview { get; set; }


        public DateTime UpcomingReview { get; set; }


        public Guid HospitalRecordId { get; set; }

        public HospitalRecord? HospitalRecord { get; set; }


    }

}