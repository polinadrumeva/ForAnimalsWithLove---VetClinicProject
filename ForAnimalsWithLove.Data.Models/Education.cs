using System.ComponentModel.DataAnnotations;

namespace ForAnimalsWithLove.Data.Models
{
    public class Education
    {
        public Education()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TrainerId { get; set; }

        public Trainer Trainer { get; set; } = null!;

        [Required]
        public int Days { get; set; }

        [Required]
        public decimal AmountPerDay { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }

}
