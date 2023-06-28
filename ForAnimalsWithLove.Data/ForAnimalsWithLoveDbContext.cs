using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using ForAnimalsWithLove.Data.Models;

namespace ForAnimalsWithLove.Data
{
    public class ForAnimalsWithLoveDbContext : IdentityDbContext<IdentityUser>
    {
        public ForAnimalsWithLoveDbContext(DbContextOptions<ForAnimalsWithLoveDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Animal> Animals { get; set; } = null!;

        public DbSet<Owner> Owners { get; set; } = null!;

        public DbSet<Doctor> Doctors { get; set; } = null!;

        public DbSet<HealthRecord> HealthRecords { get; set; } = null!;

        public DbSet<HospitalRecord> HospitalRecords { get; set; } = null!;

        public DbSet<Operation> Operations { get; set; } = null!;

        public DbSet<Test> Tests { get; set; } = null!;

        public DbSet<AnimalDoctor> AnimalsDoctors { get; set; } = null!;

        public DbSet<Hotel> Hotels { get; set; } = null!;

        public DbSet<Booking> Bookings { get; set; } = null!;

        public DbSet<AnimalBooking> AnimalsBookings { get; set; } = null!;

        public DbSet<Education> Educations { get; set; } = null!;

        public DbSet<AnimalEducation> AnimalsEducations { get; set; } = null!;

        public DbSet<Trainer> Trainers { get; set; } = null!;

        public DbSet<Grooming> Groomings { get; set; } = null!;

        public DbSet<SearchHome> SearchHomes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Animal>()
                .HasOne(a => a.HealthRecord)
                .WithOne(hr => hr.Animal)
                .HasForeignKey<HealthRecord>(hr => hr.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Grooming)
                .WithOne(hr => hr.Animal)
                .HasForeignKey<Grooming>(hr => hr.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.SearchHome)
                .WithOne(hr => hr.Animal)
                .HasForeignKey<SearchHome>(hr => hr.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<AnimalDoctor>()
                .HasKey(ad => new { ad.AnimalId, ad.DoctorId });

            modelBuilder.Entity<AnimalDoctor>()
                .HasOne(ad => ad.Doctor)
				.WithMany(a => a.AnimalsDoctors)
				.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Doctor>()
                .HasMany(ad => ad.Operations)
                .WithOne(o => o.Doctor)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Education>()
                .HasOne(e => e.Trainer)
                .WithMany(t => t.Educations)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AnimalBooking>()
              .HasKey(ab => new { ab.AnimalId, ab.BookingId });

            modelBuilder.Entity<AnimalEducation>()
                .HasKey(ae => new { ae.AnimalId, ae.EducationId });

            modelBuilder.Entity<HealthRecord>()
                .HasOne(hr => hr.Animal)
                .WithOne(a => a.HealthRecord)
                .HasForeignKey<HealthRecord>(hr => hr.AnimalId)
                .IsRequired();

            modelBuilder.Entity<HealthRecord>()
                .HasOne(hr => hr.HospitalRecord)
                .WithOne(a => a.HealthRecord)
                .HasForeignKey<HospitalRecord>(hr => hr.HealthRecordId)
                .OnDelete(DeleteBehavior.NoAction);

           modelBuilder.Entity<HospitalRecord>()
                .HasOne(hr => hr.HealthRecord)
                .WithOne(a => a.HospitalRecord)
                .HasForeignKey<HealthRecord>(hr => hr.HospitalRecordId)
                .IsRequired();

            modelBuilder.Entity<Operation>()
                .HasOne(o => o.HospitalRecord)
                .WithMany(hr => hr.Operations)
                .HasForeignKey(o => o.HospitalRecordId)
                .OnDelete(DeleteBehavior.NoAction);


        }

    }
}
