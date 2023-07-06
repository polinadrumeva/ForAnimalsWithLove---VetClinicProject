namespace ForAnimalsWithLove.Data.Models
{
    public class AnimalBooking
    {
        public int AnimalId { get; set; }

        public Animal Animal { get; set; } = null!;

        public int BookingId { get; set; }

        public Booking Booking { get; set; } = null!;
    }
}
