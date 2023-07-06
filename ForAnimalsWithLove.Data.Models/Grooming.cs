using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [StringLength(ServiceMaxLength, MinimumLength = ServiceMinLength)]
        public string Service { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }
    }
}
