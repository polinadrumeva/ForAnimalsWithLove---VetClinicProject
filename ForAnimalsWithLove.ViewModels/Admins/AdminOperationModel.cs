using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Operation;

namespace ForAnimalsWithLove.ViewModels.Admins
{
    public class AdminOperationModel
    {
        [Required]
        public Guid HospitalRecordId { get; set; }

        public AdminHospitalModel HospitalRecord { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string OperationReason { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }


        [Required]
        public Guid DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public AdminDoctorModel Doctor { get; set; } = null!;

        public virtual ICollection<AdminTestModel> Tests { get; set; }
    }
}
