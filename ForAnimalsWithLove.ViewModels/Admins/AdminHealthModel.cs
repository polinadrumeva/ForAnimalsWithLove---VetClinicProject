using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.HealthRecord;
namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminHealthModel
    {
        public AdminHealthModel()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Medicals = new HashSet<AdminMedicalModel>();
        }

        public string Id { get; set; }
        public string AnimalId { get; set; }

        public AdminAnimalModel Animal { get; set; } = null!;

        [Required]
        [Display(Name = "Микрочип")]
        public bool Microchip { get; set; }

        [StringLength(ChipMaxLength, MinimumLength = ChipMinLength)]
        [Display(Name = "Номер на микрочипа")]
        public string? MicrochipNumber { get; set; }

        [Display(Name = "Първа ваксина")]
        public bool FirstVaccine { get; set; }

        [Display(Name = "Втора ваксина")]
        public bool SecondVaccine { get; set; }

        [Display(Name = "Трета ваксина")]
        public bool ThirdVaccine { get; set; }

        [Required]
        [Display(Name = "Годишна ваксина")]
        public bool AnnualVaccine { get; set; }

        [Required]
        [StringLength(GeneralConditionMaxLength, MinimumLength = GeneralConditionMinLength)]
        [Display(Name = "Общо състояние")]
        public string GeneralCondition { get; set; } = null!;


        [StringLength(PrescriptionMaxLength, MinimumLength = PrescriptionMinLength)]
        [Display(Name = "Предписано лечение")]
        public string? PrescribedTreatment { get; set; }

        public Guid? HospitalRecordId { get; set; }

        public AdminHospitalModel? HospitalRecord { get; set; }

        public virtual ICollection<AdminMedicalModel> Medicals { get; set; }
    }
}
