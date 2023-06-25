using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnimalsWithLove.Data.Models
{
    public class AnimalDoctor
    {
        public int AnimalId { get; set; }

        public Animal Animal { get; set; } = null!;

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; } = null!;
    }
}
