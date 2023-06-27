using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnimalsWithLove.Data.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TrainerId { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; } = null!;

        [Required]
        public int Days { get; set; }

        [Required]
        public decimal AmountPerDay { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }

}
