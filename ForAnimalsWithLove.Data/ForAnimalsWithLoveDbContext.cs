using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<AnimalDoctor>()
                .HasKey(ad => new { ad.AnimalId, ad.DoctorId });

            modelBuilder.Entity<AnimalDoctor>()
                .HasOne(ad => ad.Doctor)
				.WithMany(a => a.AnimalsDoctors)
				.OnDelete(DeleteBehavior.NoAction);

         

        }


    }
}
