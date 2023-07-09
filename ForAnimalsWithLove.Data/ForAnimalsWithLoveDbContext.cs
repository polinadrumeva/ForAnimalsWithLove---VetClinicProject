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

        public DbSet<Direction> Directions { get; set; } = null!;

        public DbSet<DirectionDoctor> DirectionsDoctors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Animal>()
            //    .HasData(new Animal()
            //    {
            //        Id = 1,
            //        Name = "Пешо",
            //        Age = 2,
            //        Photo = "~/images/peshocat.jpg",
            //        KindOfAnimal = "Котка",
            //        Breed = "Сиамска",
            //        Sex = 'M',
            //        Birthdate = new DateTime(2022, 12, 12),
            //        Color = "Сив",
            //        DoesHasOwner = true,
            //        OwnerId = 1,
            //        HealthRecordId = 1
            //    });
            //    new Animal()
            //    {
            //        Id = 2,
            //        Name = "Хати",
            //        Age = 4,
            //        Photo = "~/images/haticat.jpg",
            //        KindOfAnimal = "Котка",
            //        Breed = "Хималайска",
            //        Sex = 'F',
            //        Birthdate = new DateTime(2019, 12, 12),
            //        Color = "Бял с кафеви петна",
            //        DoesHasOwner = true,
            //        OwnerId = 2,
            //        HealthRecordId = 2
            //    },
            //     new Animal()
            //     {
            //         Id = 3,
            //         Name = "Марио",
            //         Age = 1,
            //         Photo = "~/images/mariocat.jpg",
            //         KindOfAnimal = "Котка",
            //         Breed = "Регдол",
            //         Sex = 'M',
            //         Birthdate = new DateTime(2022, 08, 01),
            //         Color = "Бял",
            //         DoesHasOwner = true,
            //         OwnerId = 3,
            //         HealthRecordId = 3
            //     },
            //      new Animal()
            //      {
            //          Id = 4,
            //          Name = "Маша",
            //          Age = 5,
            //          Photo = "~/images/mashacat.jpg",
            //          KindOfAnimal = "Котка",
            //          Breed = "Руска синя",
            //          Sex = 'F',
            //          Birthdate = new DateTime(2018, 07, 21),
            //          Color = "Сив",
            //          DoesHasOwner = true,
            //          OwnerId = 4,
            //          HealthRecordId = 4
            //      },
            //       new Animal()
            //       {
            //           Id = 5,
            //           Name = "Монти",
            //           Age = 3,
            //           Photo = "~/images/monticat.jpg",
            //           KindOfAnimal = "Котка",
            //           Breed = "Улична",
            //           Sex = 'M',
            //           Birthdate = new DateTime(2021, 05, 30),
            //           Color = "Оранжев",
            //           DoesHasOwner = true,
            //           OwnerId = 5,
            //           HealthRecordId = 5
            //       },
            //        new Animal()
            //        {
            //            Id = 6,
            //            Name = "Рама",
            //            Age = 4,
            //            Photo = "~/images/ramacat.jpg",
            //            KindOfAnimal = "Котка",
            //            Breed = "Сфинкс",
            //            Sex = 'F',
            //            Birthdate = new DateTime(2019, 10, 05),
            //            Color = "Бял",
            //            DoesHasOwner = true,
            //            OwnerId = 6,
            //            HealthRecordId = 6
            //        },
            //        new Animal()
            //        {
            //             Id = 7,
            //             Name = "Тито",
            //             Age = 0,
            //             Photo = "~/images/titocat.jpg",
            //             KindOfAnimal = "Котка",
            //             Breed = "Улична",
            //             Sex = 'M',
            //             Birthdate = new DateTime(2023, 06, 09),
            //             Color = "Оранжев",
            //             DoesHasOwner = false,
            //             SearchHomeId = 1,
            //             HealthRecordId = 7
            //        },
            //         new Animal()
            //         {
            //             Id = 8,
            //             Name = "Бели",
            //             Age = 7,
            //             Photo = "~/images/belidog.jpg",
            //             KindOfAnimal = "Куче",
            //             Breed = "Годън ретривър",
            //             Sex = 'M',
            //             Birthdate = new DateTime(2016, 11, 13),
            //             Color = "Оранжев",
            //             OwnerId = 7,
            //             HealthRecordId = 8
            //         },
            //         new Animal()
            //         {
            //             Id = 9,
            //             Name = "Белла",
            //             Age = 0,
            //             Photo = "~/images/belladog.jpg",
            //             KindOfAnimal = "Куче",
            //             Breed = "Йоркширски териер",
            //             Sex = 'F',
            //             Birthdate = new DateTime(2023, 01, 02),
            //             Color = "Светло кафяв",
            //             OwnerId = 8,
            //             HealthRecordId = 9
            //         },
            //         new Animal()
            //         {
            //             Id = 10,
            //             Name = "Боби",
            //             Age = 4,
            //             Photo = "~/images/bobidog.jpg",
            //             KindOfAnimal = "Куче",
            //             Breed = "Мопс",
            //             Sex = 'M',
            //             Birthdate = new DateTime(2019, 09, 13),
            //             Color = "Бял с черни петна",
            //             OwnerId = 9,
            //             HealthRecordId = 10
            //         },
            //         new Animal()
            //         {
            //             Id = 11,
            //             Name = "Кари",
            //             Age = 0,
            //             Photo = "~/images/carydog.jpg",
            //             KindOfAnimal = "Куче",
            //             Breed = "Джак ръсел",
            //             Sex = 'F',
            //             Birthdate = new DateTime(2023, 04, 03),
            //             Color = "Бял с черни петна",
            //             OwnerId = 10,
            //             HealthRecordId = 11
            //         },
            //          new Animal()
            //          {
            //              Id = 12,
            //              Name = "Чоки",
            //              Age = 7,
            //              Photo = "~/images/chokidog.jpg",
            //              KindOfAnimal = "Куче",
            //              Breed = "Джак ръсел",
            //              Sex = 'M',
            //              Birthdate = new DateTime(2016, 10, 11),
            //              Color = "Бял с кафеви петна",
            //              OwnerId = 10,
            //              HealthRecordId = 12

            //          },
            //          new Animal()
            //          {
            //              Id = 13,
            //              Name = "Джонсън",
            //              Age = 9,
            //              Photo = "~/images/jonsundog.jpg",
            //              KindOfAnimal = "Куче",
            //              Breed = "Немска овчарка",
            //              Sex = 'M',
            //              Birthdate = new DateTime(2014, 09, 05),
            //              Color = "Кафяво-черно",
            //              OwnerId = 11,
            //              HealthRecordId = 13
            //          },
            //          new Animal()
            //          {
            //              Id = 14,
            //              Name = "Майла",
            //              Age = 4,
            //              Photo = "~/images/mailadog.jpg",
            //              KindOfAnimal = "Куче",
            //              Breed = "Улична",
            //              Sex = 'F',
            //              Color = "Кафяво-черно",
            //              DoesHasOwner = false,
            //              HealthRecordId = 14
            //          },
            //           new Animal()
            //           {
            //               Id = 15,
            //               Name = "Макси",
            //               Age = 0,
            //               Photo = "~/images/maksidog.jpg",
            //               KindOfAnimal = "Куче",
            //               Breed = "Лабрадор",
            //               Sex = 'M',
            //               Color = "Кафяво",
            //               OwnerId = 12,
            //               HealthRecordId = 15
            //           },
            //           new Animal()
            //           {
            //               Id = 16,
            //               Name = "Сара",
            //               Age = 3,
            //               Photo = "~/images/saradog.jpg",
            //               KindOfAnimal = "Куче",
            //               Breed = "Акита ину",
            //               Sex = 'F',
            //               Color = "Оранжево",
            //               OwnerId = 13,
            //               HealthRecordId = 16
            //           },
            //           new Animal()
            //           {
            //               Id = 17,
            //               Name = "Бенду",
            //               Age = 2,
            //               Photo = "~/images/benduhamster.jpg",
            //               KindOfAnimal = "Морско свинче",
            //               Breed = "Морско свинче",
            //               Sex = 'M',
            //               Color = "Бял с оранжеви и черни петна",
            //               OwnerId = 14,
            //               HealthRecordId = 17
            //           },
            //            new Animal()
            //            {
            //                Id = 18,
            //                Name = "Какару",
            //                Age = 5,
            //                Photo = "~/images/kakarupapagal.jpg",
            //                KindOfAnimal = "Папагал",
            //                Breed = "Африкански сив",
            //                Birthdate = new DateTime(2018, 12, 01),
            //                Sex = 'M',
            //                Color = "Сив",
            //                OwnerId = 15,
            //                HealthRecordId = 18
            //            },
            //             new Animal()
            //             {
            //                 Id = 19,
            //                 Name = "Малину",
            //                 Age = 1,
            //                 Photo = "~/images/malinupor.jpg",
            //                 KindOfAnimal = "Пор",
            //                 Breed = "Пор",
            //                 Birthdate = new DateTime(2022, 04, 20),
            //                 Sex = 'M',
            //                 Color = "Сив с бели петна",
            //                 OwnerId = 16,
            //                 HealthRecordId = 19
            //             },
            //              new Animal()
            //              {
            //                  Id = 20,
            //                  Name = "Сарина",
            //                  Age = 10,
            //                  Photo = "~/images/sarinahorse.jpg",
            //                  KindOfAnimal = "Кон",
            //                  Breed = "Фризийски",
            //                  Birthdate = new DateTime(2013, 03, 08),
            //                  Sex = 'F',
            //                  Color = "Черен",
            //                  OwnerId = 17,
            //                  HealthRecordId = 20
            //              }

            // );


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
            
            modelBuilder.Entity<AnimalDoctor>()
                .HasKey(ad => new { ad.AnimalId, ad.DoctorId });

            modelBuilder.Entity<AnimalDoctor>()
                .HasOne(ad => ad.Doctor)
				.WithMany(a => a.AnimalsDoctors)
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

            modelBuilder.Entity<HealthRecord>()
                .HasOne(hr => hr.HospitalRecord)
                .WithOne(a => a.HealthRecord)
                .HasForeignKey<HealthRecord>(hr => hr.HospitalRecordId)
                .IsRequired(false);

            modelBuilder.Entity<HospitalRecord>()
                .HasOne(hr => hr.HealthRecord)
                .WithOne(a => a.HospitalRecord)
                .HasForeignKey<HospitalRecord>(hr => hr.HealthRecordId)
                .IsRequired();

            modelBuilder.Entity<Operation>()
                .HasOne(o => o.HospitalRecord)
                .WithMany(hr => hr.Operations)
                .HasForeignKey(o => o.HospitalRecordId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Operation>()
                .Property(o => o.Date)
                .HasDefaultValue(DateTime.UtcNow);

        }

    }
}
