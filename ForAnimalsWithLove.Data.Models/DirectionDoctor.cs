namespace ForAnimalsWithLove.Data.Models
{
    public class DirectionDoctor
    {
        public int DirectionId { get; set; }

        public Direction Direction { get; set; } = null!;

        public Guid DoctorId { get; set; }

        public Doctor Doctor { get; set; } = null!;
    }
}
