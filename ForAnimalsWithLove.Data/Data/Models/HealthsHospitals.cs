using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnimalsWithLove.Data.Data.Models
{
    public class HealthsHospitals
    {
        public int HealthRecordId { get; set; }

        public HealthRecord HealthRecord { get; set; } = null!;

        public int HospitalRecordId { get; set; }

        public HospitalRecord HospitalRecord { get; set; } = null!;
    }
}
