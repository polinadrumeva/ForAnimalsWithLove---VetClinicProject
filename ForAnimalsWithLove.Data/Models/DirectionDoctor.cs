using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnimalsWithLove.Data.Models
{
    public class DirectionDoctor
    {
        public int DirectionId { get; set; }

        public Direction Direction { get; set; } = null!;

        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; } = null!;
    }
}
