using System.ComponentModel.DataAnnotations;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Education;

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

        //[Required]
        //[Range(typeof(decimal), AmountPerDayMinValue, AmountPerDayMaxValue)]
        //public decimal PricePerDay { get; set; }

        //[Required]
        //public decimal Amount { get { return this.Days * this.PricePerDay; } }

        
    }

}
