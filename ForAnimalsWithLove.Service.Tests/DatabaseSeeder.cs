using ForAnimalsWithLove.Data;
using ForAnimalsWithLove.Data.Models;
using System;

namespace ForAnimalsWithLove.Service.Tests
{
	public static class DatabaseSeeder
	{
		public static ApplicationUser AdminUser;
		public static ApplicationUser OwnerUser;
		public static Administrator Administrator;
		public static Owner Owner;
		public static Animal Animal;
		public static Animal Animal2;
		public static Hotel Hotel;
		public static HealthRecord HealthRecord;
		public static HospitalRecord HospitalRecord;
		public static Grooming Grooming;
		public static Doctor Doctor;
		public static Direction Direction;
		public static Trainer trainer1;
		public static Trainer trainer2;
		public static Education education;


		public static void SeedDatabase(ForAnimalsWithLoveDbContext dbContext)
		{
			AdminUser = new ApplicationUser()
			{
				Id = Guid.Parse("EE9AC98E-AE74-4D80-BF45-D559501BE6F2"),
				UserName = "daneva@foranimalswithlove.bg",
				NormalizedUserName = "DANEVA@FORANIMALSWITHLOVE.BG",
				Email = "daneva@foranimalswithlove.bg",
				NormalizedEmail = "DANEVA@FORANIMALSWITHLOVE.BG",
				EmailConfirmed = false,
				PasswordHash = "AQAAAAEAACcQAAAAELofJgVBIs6Xe2iOGTkF51ucVkQZAbNLRSADKmmrQ4A2GrktlKRuqJAcIkcEHFMqww==",
				ConcurrencyStamp = "2f549437-4f4d-4283-8cde-f6e8afc54e4f",
				SecurityStamp = "TAKWH2VBFZ6LCPGGNS5SJYH7LAEZIQTU",
				TwoFactorEnabled = false
			};

			Administrator = new Administrator()
			{
				FirstName = "Маргарита",
				LastName = "Данева",
				PhoneNumber = "0887554289",
				UserId = Guid.Parse("EE9AC98E-AE74-4D80-BF45-D559501BE6F2")
			};

			OwnerUser = new ApplicationUser()
			{
				Id = Guid.Parse("5727d951-24ba-4450-8cb5-6e851a9b1d4b"),
				UserName = "polina_drumeva@abv.bg",
				NormalizedUserName = "POLINA_DRUMEVA@ABV.BG",
				Email = "polina_drumeva@abv.bg",
				NormalizedEmail = "POLINA_DRUMEVA@ABV.BG",
				EmailConfirmed = false,
				PasswordHash = "AQAAAAEAACcQAAAAEDTR/+36bHk8hbJQYwsuyvPOGZEItfdQ76C+1/YHjIioLwC/eDcdkxo9w9kr/x/lRQ==",
				ConcurrencyStamp = "e5545227-eab6-466c-b788-5fc9b8a1058c",
				SecurityStamp = "MTWXHPFEXJG35RO2V56TOLAZF2LHIQQC",
				TwoFactorEnabled = false
			};

			Owner = new Owner()
			{
				Id = Guid.Parse("F88EF877-1938-41AD-992D-A08F59B45EAF"),
				FirstName = "Полина",
				LastName = "Друмева",
				PhoneNumber = "0887554289",
				Address = "Велико Търново",
				UserId = Guid.Parse("5727d951-24ba-4450-8cb5-6e851a9b1d4b")
			};

			Animal = new Animal()
			{
				Id = Guid.Parse("3FA15101-2A77-453B-9891-97301E778C39"),
				Name = "Чоки",
				Age = 7,
				KindOfAnimal = "Куче",
				Breed = "Джак ръсел",
				Sex = 'M',
				Birthdate = new DateTime(2016, 10, 11),
				Color = "Бял с кафеви петна",
				DoesHasOwner = true,
				OwnerId = Guid.Parse("f88ef877-1938-41ad-992d-a08f59b45eaf"),
				Owner = Owner,
				GroomingId = Guid.Parse("C69A75E6-A5AE-4974-81C7-206CB069342B"),
				HealthRecordId = Guid.Parse("6F66D5E0-4B8F-45C3-931A-D5833C63DBD2"),
				
			};

			Grooming = new Grooming()
			{
				Date = new DateTime(2023, 10, 11),
				AnimalId = Guid.Parse("3FA15101-2A77-453B-9891-97301E778C39"),
				Animal = Animal,
				Service = "Стрижка"
			};


			Animal2 = new Animal()
			{
				Id = Guid.Parse("7a090717-e16a-45e7-9d46-bd804ec499b5"),
				Name = "Чок",
				Age = 7,
				KindOfAnimal = "Куче",
				Breed = "Джак ръсел",
				Sex = 'M',
				Birthdate = new DateTime(2016, 10, 11),
				Color = "Бял с кафеви петна",
				DoesHasOwner = true

			};

			Hotel = new Hotel()
			{
				Id = 1,
				Name = "For Animals With Love",
				Location = "Велико Търново",
			};

			HealthRecord = new HealthRecord()
			{
				Id = Guid.Parse("6F66D5E0-4B8F-45C3-931A-D5833C63DBD2"),
				AnimalId = Guid.Parse("3FA15101-2A77-453B-9891-97301E778C39"),
				Animal = Animal,
				Microchip = false,
				FirstVaccine = false,
				SecondVaccine = false,
				ThirdVaccine = false,
				AnnualVaccine = false,
				GeneralCondition = "Добро",
				
			};

			HospitalRecord = new HospitalRecord()
			{
				DateOfAcceptance = new DateTime(2023, 10, 11),
				DateOfDischarge = new DateTime(2023, 10, 15),
				Diagnosis = "Заразен",
				Treatment = "Антибиотици",
				PrescribedTreatment = "Антибиотици"
			};

			Doctor = new Doctor()
			{
				FirstName = "Димитър",
				LastName = "Димитров",
				PhoneNumber = "0887554289",
				Address = "Велико Търново",
				Photo = "https://res.cloudinary.com/dimitrov/image/upload/v1634496824/Doctor/doctor1.jpg",
				UserId = Guid.Parse("5727D951-24BA-4450-8CB5-6E851A9B1D4B")
			};

			Direction = new Direction()
			{
				Name = "Хирургия",
			};

			var trainer1 = new Trainer
			{
				Id = Guid.NewGuid(),
				FirstName = "John",
				LastName = "Doe",
				PhoneNumber = "555-1234",
				Photo = "photo1.jpg"
			};

			var trainer2 = new Trainer
			{
				Id = Guid.NewGuid(),
				FirstName = "Jane",
				LastName = "Smith",
				PhoneNumber = "555-5678",
				Photo = "photo2.jpg"
			};

			var education = new Education
			{
				Id = Guid.Parse("38AF2361-8ABF-4A6E-91E6-03369453828E"),
				Days = 10,
				TrainerId = trainer1.Id,
			};
           

			dbContext.Users.Add(AdminUser);
			dbContext.Administrators.Add(Administrator);
			dbContext.Users.Add(OwnerUser);
			dbContext.Owners.Add(Owner);
			dbContext.Animals.Add(Animal);
			dbContext.Animals.Add(Animal2);
			dbContext.Groomings.Add(Grooming);
			dbContext.Hotels.Add(Hotel);
			dbContext.HealthRecords.Add(HealthRecord);
			dbContext.HospitalRecords.Add(HospitalRecord);
			dbContext.Doctors.Add(Doctor);
			dbContext.Directions.Add(Direction);
			dbContext.Trainers.AddRange(trainer1, trainer2);
			dbContext.Educations.Add(education);

			dbContext.SaveChanges();
		}
	}
}

