using System.ComponentModel.DataAnnotations;


namespace ForAnimalsWithLove.Data.Models
{
    public class Test
    {
        public Test()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PKK { get; set; } = null!;

        [Required]
        public string Urine { get; set; } = null!;

        public string? ImagingDiagnosis { get; set; }
    }
}
