using ForAnimalsWithLove.Data;
using ForAnimalsWithLove.Data.Models;
using System;

namespace ForAnimalsWithLove.Service.Tests
{
	public class DatabaseSeeder
	{
		public static ApplicationUser AdminUser;
		public static ApplicationUser OwnerUser;
		public static Administrator Administrator;

		public static void SeedDatabase(ForAnimalsWithLoveDbContext dbContext)
		{
			AdminUser = new ApplicationUser()
			{
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
			//OwnerUser = new ApplicationUser()
			//{
			//	UserName = "creator@softuni.bg",
			//	NormalizedUserName = "CREATOR@SOFTUNI.BG",
			//	Email = "creator@softuni.bg",
			//	NormalizedEmail = "CREATOR@SOFTUNI.BG",
			//	EmailConfirmed = false,
			//	PasswordHash = "AQAAAAEAACcQAAAAEAQaPg7NZbeXCRB+T8sZ9vvV5EG6gyOsdRJhryLKf4aVt7saTmsEdl/ZrchXTgDDeg==",
			//	ConcurrencyStamp = "6fd79cd5-1103-4a35-b86a-4f4885c722a2",
			//	SecurityStamp = "XWMRYEHMONJLBYXMYQHZBEFJEVFQ6Y67",
			//	TwoFactorEnabled = false
			//};
			

			dbContext.Users.Add(AdminUser);
			//dbContext.Users.Add(OwnerUser);
			dbContext.Administrators.Add(Administrator);

			dbContext.SaveChanges();
		}
	}
}

