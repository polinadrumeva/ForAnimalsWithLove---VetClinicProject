using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForAnimalsWithLove.Data.Models
{
    public class SearchHome
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid AnimalId { get; set; }

        [ForeignKey(nameof(AnimalId))]
        public Animal Animal { get; set; } = null!;

        
        public string? Location { get; set; } 

       
        public string? Habits { get; set; } 
    }

}
