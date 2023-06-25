using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static ForAnimalsWithLove.Common.Validations.EntityValidations.HealthRecord;

namespace ForAnimalsWithLove.Data.Models
{
    public class HealthRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
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

       
        public int? HospitalRecordId { get; set; }

        [ForeignKey(nameof(HospitalRecordId))]
        public HospitalRecord? HospitalRecord { get; set; }


    }

}
