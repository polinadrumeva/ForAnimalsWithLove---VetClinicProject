using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ForAnimalsWithLove.Common.Validations.EntityValidations.Doctor;

namespace ForAnimalsWithLove.Data.Models
{
    public class Direction
    {
        public Direction()
        {
            this.DirectionsDoctors = new HashSet<DirectionDoctor>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DirectionMaxLength, MinimumLength = DirectionMinLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<DirectionDoctor> DirectionsDoctors { get; set; } 
    }
}
