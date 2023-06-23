using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnimalsWithLove.Data.Data.Models
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
