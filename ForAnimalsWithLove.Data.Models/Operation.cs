using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Operation;

namespace ForAnimalsWithLove.Data.Models
{
    public class Operation
    {
        public Operation()
        {
            this.Id = Guid.NewGuid();
            this.Tests = new HashSet<Test>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid HospitalRecordId { get; set; }

        
        public HospitalRecord HospitalRecord { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string OperationReason { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(typeof(decimal),AmountMinValue, MaxPriceOperation)]
        public decimal Price { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = null!;

        public virtual ICollection<Test> Tests { get; set; }


    }


}
