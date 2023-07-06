using System.ComponentModel.DataAnnotations;


namespace ForAnimalsWithLove.Data.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PKK { get; set; } = null!;

        [Required]
        public string Urine { get; set; } = null!;

        public string? ImagingDiagnosis { get; set; }
    }
}
