using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.Data.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; } = null!;

        [Required]
        public int Days { get; set; }

        [Required]
        public decimal AmountPerDay { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }

}
