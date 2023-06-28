using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ForAnimalsWithLove.Common.Validations.EntityValidations.Grooming;

namespace ForAnimalsWithLove.Data.Models
{
    public class Grooming
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public Animal Animal { get; set; } = null!;

        [Required]
        [StringLength(ServiceMinLength, MinimumLength = ServiceMinLength)]
        public string Service { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }
    }
}
