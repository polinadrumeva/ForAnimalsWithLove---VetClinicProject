namespace ForAnimalsWithLove.Data.Models
{
    public class AnimalDoctor
    {
        public Guid AnimalId { get; set; }

        public Animal Animal { get; set; } = null!;

        public Guid DoctorId { get; set; }

        public Doctor Doctor { get; set; } = null!;
    }
}
