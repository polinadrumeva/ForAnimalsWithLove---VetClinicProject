using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnimalsWithLove.Data.Models
{
    public class AnimalEducation
    {
        public int AnimalId { get; set; }

        public Animal Animal { get; set; } = null!;

        public int EducationId { get; set; }

        public Education Education { get; set; } = null!;
    }
}
