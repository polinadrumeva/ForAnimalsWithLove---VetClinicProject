namespace ForAnimalsWithLove.Data.Models
{
    public class AnimalEducation
    {
        public Guid AnimalId { get; set; }

        public Animal Animal { get; set; } = null!;

        public Guid EducationId { get; set; }

        public Education Education { get; set; } = null!;
    }
}
