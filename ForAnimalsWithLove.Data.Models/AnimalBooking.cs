namespace ForAnimalsWithLove.Data.Models
{
    public class AnimalBooking
    {
        public Guid AnimalId { get; set; }

        public Animal Animal { get; set; } = null!;

        public Guid BookingId { get; set; }

        public Booking Booking { get; set; } = null!;
    }
}
