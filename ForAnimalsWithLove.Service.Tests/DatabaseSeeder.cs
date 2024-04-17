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
				Id = Guid.Parse("5727D951-24BA-4450-8CB5-6E851A9B1D4B"),
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
				FirstName = "Полина",
				LastName = "Друмева",
				PhoneNumber = "0887554289",
				Address = "Велико Търново",
				UserId = Guid.Parse("5727D951-24BA-4450-8CB5-6E851A9B1D4B")
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
				OwnerId = Guid.Parse("F88EF877-1938-41AD-992D-A08F59B45EAF"),
				Owner = Owner,
				GroomingId = Guid.Parse("C69A75E6-A5AE-4974-81C7-206CB069342B"),
				HealthRecordId = Guid.Parse("6F66D5E0-4B8F-45C3-931A-D5833C63DBD2"),

			};

			dbContext.Users.Add(AdminUser);
			dbContext.Administrators.Add(Administrator);
			dbContext.Users.Add(OwnerUser);
			dbContext.Owners.Add(Owner);
			dbContext.Animals.Add(Animal);

			dbContext.SaveChanges();
		}
	}
}

