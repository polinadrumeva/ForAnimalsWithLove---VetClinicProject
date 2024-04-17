using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using ForAnimalsWithLove.Data.Models;
using System.Reflection;

namespace ForAnimalsWithLove.Data
{
	public class ForAnimalsWithLoveDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
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

		public DbSet<Medical> Medicals { get; set; } = null!;

		public DbSet<Hotel> Hotels { get; set; } = null!;

		public DbSet<Booking> Bookings { get; set; } = null!;

		public DbSet<AnimalBooking> AnimalsBookings { get; set; } = null!;

		public DbSet<Education> Educations { get; set; } = null!;

		public DbSet<AnimalEducation> AnimalsEducations { get; set; } = null!;

		public DbSet<Trainer> Trainers { get; set; } = null!;

		public DbSet<Grooming> Groomings { get; set; } = null!;

		public DbSet<SearchHome> SearchHomes { get; set; } = null!;

		public DbSet<Direction> Directions { get; set; } = null!;

		public DbSet<DirectionDoctor> DirectionsDoctors { get; set; } = null!;

		public DbSet<Administrator> Administrators { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Animal>()
				 .HasOne(a => a.HealthRecord)
				 .WithOne(hr => hr.Animal)
				 .HasForeignKey<HealthRecord>(hr => hr.AnimalId)
				 .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Animal>()
				.HasOne(a => a.Grooming)
				.WithOne(hr => hr.Animal)
				.HasForeignKey<Grooming>(hr => hr.AnimalId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Animal>()
				.HasOne(a => a.SearchHome)
				.WithOne(hr => hr.Animal)
				.HasForeignKey<SearchHome>(hr => hr.AnimalId)
				.OnDelete(DeleteBehavior.Restrict);


			modelBuilder.Entity<Doctor>()
				.HasMany(ad => ad.Operations)
				.WithOne(o => o.Doctor)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<DirectionDoctor>()
				.HasKey(dd => new { dd.DirectionId, dd.DoctorId });

			modelBuilder.Entity<Education>()
				.HasOne(e => e.Trainer)
				.WithMany(t => t.Educations)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<AnimalBooking>()
			  .HasKey(ab => new { ab.AnimalId, ab.BookingId });

			modelBuilder.Entity<AnimalEducation>()
				.HasKey(ae => new { ae.AnimalId, ae.EducationId });


			modelBuilder.Entity<HealthRecord>()
				.HasOne(hr => hr.Animal)
				.WithOne(a => a.HealthRecord)
				.HasForeignKey<HealthRecord>(hr => hr.AnimalId)
				.IsRequired();


			modelBuilder.Entity<HospitalRecord>()
				.HasOne(hr => hr.HealthRecord)
				.WithMany(a => a.HospitalsRecords)
				.IsRequired();

			modelBuilder.Entity<Operation>()
				.HasOne(o => o.HospitalRecord)
				.WithMany(hr => hr.Operations)
				.HasForeignKey(o => o.HospitalRecordId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Operation>()
				.Property(o => o.Date)
				.HasDefaultValue(DateTime.UtcNow);

			modelBuilder.Entity<Administrator>()
				.HasMany(a => a.HealthRecords);

			modelBuilder.Entity<Administrator>()
				.HasMany(a => a.HospitalRecords);



			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ForAnimalsWithLoveDbContext))
																			?? Assembly.GetExecutingAssembly());

		}

	}
}
