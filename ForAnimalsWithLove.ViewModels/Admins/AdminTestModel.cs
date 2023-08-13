using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminTestModel
    {
        [Required]
        public string PKK { get; set; } = null!;

        [Required]
        public string Urine { get; set; } = null!;

        public string? ImagingDiagnosis { get; set; }
    }
}
