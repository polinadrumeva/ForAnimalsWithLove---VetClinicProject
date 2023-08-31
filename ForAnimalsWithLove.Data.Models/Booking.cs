using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static ForAnimalsWithLove.Common.Validations.EntityValidations.Booking;

namespace ForAnimalsWithLove.Data.Models
{
    public class Booking
    {
        public Booking()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; } = null!;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(ValidMinDays, ValidMaxDays)]
        public int Days { get; set; }

        [Required]
        [Range(typeof(decimal), AmountMinValue, AmountMaxValue)]
        public decimal Amount { get { return this.Days * this.Hotel.PricePerDay; } }

        
    }

}
